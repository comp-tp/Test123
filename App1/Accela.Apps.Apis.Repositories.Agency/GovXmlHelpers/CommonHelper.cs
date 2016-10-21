using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Automation.GovXmlClient.Model;
using Accela.Automation.GovXmlServices.Client;
using Accela.Apps.Apis.Resources;
using Accela.Core.Ioc;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Admin.Agency.Client;
using Accela.Apps.Admin.Agency.Client.Models;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    /// <summary>
    /// Get response system from gov xml
    /// </summary>
    /// <param name="govXmlOut">the response govxml</param>
    /// <returns>return the response system</returns>
    public delegate Sys GetResponseSys(GovXML govXmlOut);

    public class CommonHelper : GovXmlHelperBase
    {
        private string _agencyName;
        private string _agencyUser;
        private string _serviceProvCode;
        private string _environmentName;
        private string _token;
        private string _language;
        private string _traceId;

        public bool IsGettingI18NSetting
        {
            get;
            set;
        }

        private HostEnvironmentModel _environment;
        public HostEnvironmentModel Environment
        {
            get
            {
                if (_environment == null)
                {
                    SetupHostAndEnvironment();
                }

                return _environment;
            }
        }

        private void SetupHostAndEnvironment()
        {
            var agencyService = IocContainer.Resolve<IAgencySettingsService>();

            // GetEnvironment will throw correct error message
            var envInfo = agencyService.GetEnvironment(_agencyName, _environmentName);
            _environment = envInfo;
        }

        public CommonHelper(string agencyName, string agencyUser, string serviceProvCode, string environmentName, string token, string language, string traceId)
        {
            if (String.IsNullOrEmpty(agencyName))
            {
                throw new ArgumentNullException("agencyName cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(agencyUser))
            {
                throw new ArgumentNullException("agencyUser cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(serviceProvCode))
            {
                throw new ArgumentNullException("serviceProvCode cannnot be null or empty.");
            }

            if (String.IsNullOrEmpty(environmentName))
            {
                throw new ArgumentNullException("environmentName cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token cannot be null or empty.");
            }

            _agencyName = agencyName;
            _agencyUser = agencyUser;
            _serviceProvCode = serviceProvCode;
            _environmentName = environmentName;

            _token = token;
            _language = language;
            if (String.IsNullOrEmpty(_language))
            {
                _language = "en-US";
            }
            _language = _language.Replace("_", "-");
            _traceId = traceId;
        }

        public Sys GetSystem(RequestBase request, IAgencyAppContext agencyContext, bool isCreateRecord = false)
        {
            if (request != null)
            {
                return GetSystemFromPosition(request.Offset, request.Limit, agencyContext, isCreateRecord);
            }
            else
            {
                return GetSystemFromPosition(0, 0, agencyContext, isCreateRecord);
            }
        }

        public Sys GetSystemFromPosition(int offset, int limit, IAgencyAppContext agencyContext, bool isCreateRecord = false)
        {
            // Use default system context for all Mobile Server and Automation Integration. 
            // In future, when AMO also starts using this Mobile Server, we can have client pass it or figure this smartly in web services and set it here.

            var sys = new Sys { context = "AccelaMobileOffice" };

            var envInfo = this.Environment;

            if (envInfo == null)
            {
                string error = MobileResources.GetString("environment_no_exist");
                throw new MobileException(error);
            }

            string bizServerVersion = envInfo.BizServerVersion;

            if (IsBizVersion730AndLater(bizServerVersion))
            {
                if (isCreateRecord)
                {
                    if (agencyContext.AppName.ToLowerInvariant().Contains("inspector"))
                    {
                        sys.context = "AccelaInspector";
                    }

                    if (agencyContext.AppName.ToLowerInvariant().Contains("officer"))
                    {
                        sys.context = "AccelaCodeOfficer";
                    }

                    if (agencyContext.AppName.ToLowerInvariant().Contains("crew"))
                    {
                        sys.context = "AccelaWorkCrew";
                    }
                }
            }

            sys.xmlVersion = ConvertXMLVersion(bizServerVersion);

            sys.serviceProviderCode = _serviceProvCode.Trim();
            
            sys.username = _agencyUser;
            sys.applicationState = _token;

            sys.startRow = offset + 1;
            sys.maxRows = limit;

            // check and update default language 
            if (IsGettingI18NSetting)
            {
                _language = "en-US";
            }
            else
            {
                IStandardChoiceRepository refRep = IocContainer.Resolve<IStandardChoiceRepository>();

                var stdChoiceRequest = new GetStandardChoicesRequest { StandardChoiceType = "I18N_LANGUAGES" };
                var languageKeys = refRep.GetI18NLanguageSettings(stdChoiceRequest, agencyContext);

                if (languageKeys.Count > 0 && !languageKeys.Contains(_language))
                {
                    var splitLanguageAndRegion = _language.Split(new[] { '-' },StringSplitOptions.RemoveEmptyEntries);

                    var matchingLanguage = languageKeys.FirstOrDefault(t => t.StartsWith(splitLanguageAndRegion[0]));

                    if (matchingLanguage != null)
                    {
                        _language = matchingLanguage;
                    }
                    else
                    {
                        var matchingRegion = languageKeys.FirstOrDefault(t => t.EndsWith(splitLanguageAndRegion[1]));

                        if (matchingRegion != null)
                        {
                            _language = matchingRegion;
                        }
                        else
                        {
                            // It needs to check another standard choice to figure out what the default language is.
                            _language = languageKeys[0];
                        }
                    }
                }
               
            }

            sys.language = _language;

            return sys;
        }

        public static string ProcessGovXmlErrors(Sys system, FSystemOut systemOut)
        {
            string result = "0";
            Sys sys = null;
            if (system != null)
            {
                sys = system;
            }
            else if (systemOut != null)
            {
                sys = systemOut.system;
            }

            // return error code instead of throw exception
            if (sys != null)
            {
                if (sys.error != null && !string.IsNullOrWhiteSpace(sys.error.errorCode) && sys.error.errorCode != "0")
                {
                    result = sys.error.errorCode;
                    // throw new MobileException(sys.error.errorCode, sys.error.errorMessage, sys.error.errorDetail);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(sys.errorCode) && sys.errorCode != "0")
                    {
                        result = sys.errorCode;
                        //throw new MobileException(sys.errorCode, sys.errorMessage);
                    }
                }
            }

            return result;
        }

        private GovXML Post(GovXML govXmlIn)
        {
            ICommunicator GovCommunicator = IocContainer.Resolve<ICommunicator>();

            GovXML govXMLRet = null;

            try
            {
                long begin = DateTime.UtcNow.Ticks;
                string requestString = XmlConverter.ToXml(govXmlIn);
                govXMLRet = GovCommunicator.Post<GovXML>(requestString);

                if (Log.IsInfoEnabled)
                {
                    int methodExcuteTime = Convert.ToInt32(new TimeSpan(DateTime.UtcNow.Ticks - begin).TotalMilliseconds);
                    string requestMethodName = GetRequestName(govXmlIn);

                    // TODO:
                    // Use the new DLL
                    // Remove the below code later because there is no such thing in the new DLL.
                    //Log.Performance(Reflection.CurrentMethodName, methodExcuteTime, requestMethodName);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, Reflection.CurrentMethodName);

                // TODO:
                // Use the new DLL
                // Remove the below code later because there is no such thing in the new DLL.
                //if (Log.IsTransactionEnabled)
                //{
                //    Log.Transaction("GovXML Post Exception", ex.ToString(), Reflection.CurrentMethodName);
                //}
                throw;
            }

            if (govXMLRet == null)
            {
                throw new MobileException(MobileResources.GetString("no_govxml_retrurn"));
            }

            return govXMLRet;
        }

        public GovXML Post(GovXML govXmlIn, Sys requestSys, GetResponseSys getResponseSys)
        {
            LogTransactionLog(govXmlIn);

            GovXML govXMLRet = null;

            var watch2 = Reflection.Startwatch();

            govXMLRet = Post(govXmlIn);

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch2), "CommonHelper.Post - do Post", "");

            var watch3 = Reflection.Startwatch();
            Sys retSys = null;
            if (govXMLRet.fSystemOut == null)
            {
                retSys = getResponseSys(govXMLRet);
            }

            LogTransactionLog(govXMLRet);

            #region ProcessGovXmlErrors

            string errorCode = "";
            string errorMessage = "";
            Sys sys = null;
            if (retSys != null)
            {
                sys = retSys;
            }
            else if (govXMLRet.fSystemOut != null)
            {
                sys = govXMLRet.fSystemOut.system;
            }

            // return error code instead of throw exception
            if (sys != null)
            {
                if (sys.error != null && !string.IsNullOrWhiteSpace(sys.error.errorCode) && sys.error.errorCode != "0")
                {
                    errorCode = sys.error.errorCode;
                    errorMessage = sys.error.errorMessage;
                    throw new MobileException(sys.error.errorMessage, sys.error.errorDetail, sys.error.errorCode);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(sys.errorCode) && sys.errorCode != "0")
                    {
                        errorCode = sys.errorCode;
                        errorMessage = sys.errorMessage;
                        throw new MobileException(sys.errorMessage, String.Empty, sys.errorCode);
                    }
                }
            }

            #endregion

            //1001,1002 is mean session expired
            if ((errorCode == GovXmlErrorCode.Expired1 || errorCode == GovXmlErrorCode.Expired2)
                || (errorCode == GovXmlErrorCode.Expired3 && errorMessage.IndexOf("InvalidSessionException") >= 0)
                )
            {
                throw new UnauthorizedException(MobileResources.GetString("remote_session_expired"));
            }
            else if (!string.IsNullOrWhiteSpace(sys.errorCode) && sys.errorCode != "0")
            {
                throw new MobileException(errorMessage);
            }

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //if(Log.IsInfoEnabled)
            //    Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch3), "CommonHelper.Post - ProcessGovXmlErrors etc...","");

            return govXMLRet;
        }

        private static int GetRandomNumber(int maxNumber)
        {
            if (maxNumber < 1)
                throw new System.Exception(MobileResources.GetString("get_randomnumber_parameter_value_range"));

            byte[] b = new byte[4];

            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);

            int seed = (b[0] & 0x7f) << 24 | b[1] << 16 | b[2] << 8 | b[3];

            System.Random r = new System.Random(seed);

            return r.Next(0, maxNumber);
        }

        public static void LogTransactionLog(GovXML govXML)
        {
            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //if (Log.IsTransactionEnabled)
            //{
            //    if (govXML != null)
            //    {
            //        string name = GetRequestName(govXML);
            //        string content = Accela.Apps.Shared.XmlConverter.ToXml(govXML);
            //        Log.Transaction(name, content, Reflection.CurrentMethodName);
            //    }
            //}
        }

        private static string GetRequestName(GovXML xmlin)
        {
            System.Type govxmlType = typeof(GovXML);
            FieldInfo[] fields = govxmlType.GetFields();
            foreach (var field in fields)
            {
                if (field.GetValue(xmlin) != null)
                {
                    return field.Name;
                }
            }

            PropertyInfo[] propertys = govxmlType.GetProperties();
            foreach (var property in propertys)
            {
                if (property.GetValue(xmlin, null) != null)
                {
                    return property.Name;
                }
            }
            return string.Empty;
        }

        public static int GetTimeout()
        {
            return 300;
        }

        public static bool GetDebugMode()
        {
            return false;
        }

        public static string GetPersonName(Person person)
        {
            string result = String.Empty;

            if (person != null)
            {
                var middleArray = person.middleNames != null && person.middleNames.String != null && person.middleNames.String.Length > 0 ? person.middleNames.String : null;
                result = GetFullName(person.fullName, person.givenName, middleArray, person.familyName);
            }

            return result;
        }

        public static string GetFullName(string fullName, string firstName, string[] middleNameArray, string lastName)
        {
            string result = String.Empty;

            if (!String.IsNullOrWhiteSpace(fullName))
            {
                result = fullName;
            }
            else
            {
                var allNames = new List<string>();
                allNames.Add(firstName);

                if (middleNameArray != null)
                {
                    allNames.AddRange(middleNameArray);
                }

                allNames.Add(lastName);
                var allNameArray = allNames.Where(n => !String.IsNullOrWhiteSpace(n)).ToArray();

                if (allNameArray != null && allNameArray.Length > 0)
                {
                    result = string.Join(" ", allNameArray);
                }
            }

            return result;
        }

        public static Pagination GetPaginationFromSystem(Sys sys)
        {

            if (sys != null)
            {
                return new Pagination()
                {
                    Offset = sys.startRow - 1,
                    Limit = sys.endRow - sys.startRow + 1,
                    TotalRows = sys.totalRows
                };
            }
            return null;
        }

        public static Pagination GetPaginationFromResult(RequestBase request, IList resultList, int totalRows)
        {
            Pagination result = null;

            if (resultList != null)
            {
                result = new Pagination()
                {
                    Offset = request.Offset,
                    Limit = resultList.Count,
                    TotalRows = totalRows,

                };
            }

            return result;
        }

        public static List<Accela.Apps.Apis.Models.DomainModels.EventMessage> GetClientEventMessage(EventMessages xmlObjs)
        {
            List<Accela.Apps.Apis.Models.DomainModels.EventMessage> retus = null;
            if (xmlObjs != null && xmlObjs.eventMessage != null)
            {
                retus = new List<Accela.Apps.Apis.Models.DomainModels.EventMessage>();
                foreach (var xmlObj in xmlObjs.eventMessage)
                {
                    Accela.Apps.Apis.Models.DomainModels.EventMessage message = new Accela.Apps.Apis.Models.DomainModels.EventMessage();
                    message.EventCode = xmlObj.Code;
                    message.Message = xmlObj.Text;
                    message.DetailInfo = xmlObj.Detail;
                    retus.Add(message);
                }
            }

            return retus;
        }

        public static string ToGovXmlAction(string action)
        {
            /*
             * Here is the GovXML schema:
               <xsd:simpleType name="dataitemChangeEnum">
                 <xsd:restriction base="xsd:string">
                 <xsd:enumeration value="Add"/>
                 <xsd:enumeration value="Append"/>
                 <xsd:enumeration value="Delete"/>
                 <xsd:enumeration value="Existing"/>
                 <xsd:enumeration value="New"/>
                 <xsd:enumeration value="Replace"/>
                 <xsd:enumeration value="Readonly"/>
                 <xsd:enumeration value="Update"/>
                 </xsd:restriction>
               </xsd:simpleType>
           //*/

            switch (action)
            {
                case ActionDataModel.UPDATED:
                    return "Update";
                case ActionDataModel.DELETED:
                    return "Delete";
                case ActionDataModel.ADDED:
                    return "Add";
                case ActionDataModel.NORMAL:
                    return "Existing";
                default:
                    return action;
            }
        }

        public static double ToDouble(string str)
        {
            double retu;
            double.TryParse(str, out retu);
            return retu;
        }

        public static double? ToNuableDouble(string str)
        {
            double retu;
            if (double.TryParse(str, out retu))
            {
                return retu;
            }

            return null;
        }
    }


    public static class CommonHelperExtension
    {
        public static List<T> ToPagedList<T>(this IList<T> allEntities, RequestBase request)
        {
            if (allEntities == null)
            {
                allEntities = new List<T>();
            }
            bool isRequestAll = request.Offset == 0 && request.Limit == 0;
            return isRequestAll ? allEntities.ToList() : allEntities.Skip(request.Offset).Take(request.Limit).ToList();
        }
    }
}
