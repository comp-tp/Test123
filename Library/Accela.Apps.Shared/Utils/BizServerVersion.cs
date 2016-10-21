using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.Utils
{
    /// <summary>
    /// sample: "7.3.3.0.0_275386"
    /// </summary>
    public class BizServerVersion
    {
        int _major = 0;
        int _minor = 0;
        int _revision = 0;
        int _featurePack = 0;
        int _hotfix = 0;
        int _build = 0;
        const int END_INDEX = 5;

        public BizServerVersion(string versionString)
        {
            Extract(versionString);
        }

        private void Extract(string versionString)
        {
            if (String.IsNullOrWhiteSpace(versionString))
            {
                return;
            }

            var partsByBuild = versionString.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
            var mainString = versionString;

            if (partsByBuild != null && partsByBuild.Length == 2)
            {
                mainString = partsByBuild[0];
                this._build = TryConvertToInt(partsByBuild[1]);
            }

            var mainParts = mainString.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            if (mainParts != null)
            {
                this._major = mainParts.Length > 0 ? TryConvertToInt(mainParts[0]) : 0;
                this._minor = mainParts.Length > 1 ? TryConvertToInt(mainParts[1]) : 0;
                this._revision = mainParts.Length > 2 ? TryConvertToInt(mainParts[2]) : 0;
                this._featurePack = mainParts.Length > 3 ? TryConvertToInt(mainParts[3]) : 0;
                this._hotfix = mainParts.Length > 4 ? TryConvertToInt(mainParts[4]) : 0;
            }
        }

        private int TryConvertToInt(string part)
        {
            int result = 0;
            int tempResult;
            if (int.TryParse(part, out tempResult))
            {
                result = tempResult;
            }

            return result;
        }

        private int[] GetPartArray(BizServerVersion version)
        {
            var partArray = new int[] { version._major, version._minor, version._revision, version._featurePack, version._hotfix, version._build };
            return partArray;
        }

        public bool GreaterThan(BizServerVersion version)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            var thisVersionParts = GetPartArray(this);
            var comparedVersionParts = GetPartArray(version);
            var result = false;

            for (int i = 0; i <= END_INDEX; i++)
            {
                if (thisVersionParts[i] > comparedVersionParts[i])
                {
                    result = true;
                    break;
                }
                else if (thisVersionParts[i] == comparedVersionParts[i])
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public bool GreaterThanOrEqual(BizServerVersion version)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            var thisVersionParts = GetPartArray(this);
            var comparedVersionParts = GetPartArray(version);
            var result = false;

            for (int i = 0; i <= END_INDEX; i++)
            {
                if (thisVersionParts[i] > comparedVersionParts[i])
                {
                    result = true;
                    break;
                }
                else if (thisVersionParts[i] == comparedVersionParts[i])
                {
                    if (i == END_INDEX)
                    {
                        result = true;
                    }
                    continue;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public bool Equal(BizServerVersion version)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            var thisVersionParts = GetPartArray(this);
            var comparedVersionParts = GetPartArray(version);
            var result = false;

            for (int i = 0; i <= END_INDEX; i++)
            {
                if (thisVersionParts[i] != comparedVersionParts[i])
                {
                    result = false;
                    break;
                }
                else if (i == END_INDEX)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool LessThan(BizServerVersion version)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            var result = !GreaterThanOrEqual(version);
            return result;
        }

        public bool LessThanOrEqual(BizServerVersion version)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            var result = !GreaterThan(version);
            return result;
        }
    }
}
