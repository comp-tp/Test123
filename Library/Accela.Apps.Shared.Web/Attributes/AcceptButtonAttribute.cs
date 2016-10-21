using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accela.Apps.Shared.Web.Attributes
{
    public class AcceptButtonAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public AcceptButtonAttribute(string name)
        {
            this.Name = name;
        }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, System.Reflection.MethodInfo methodInfo)
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return false;
            }

            bool retu=false;
            retu= controllerContext.HttpContext.Request.Form.AllKeys.Contains(this.Name);
            if(retu==false)
            {
                retu = controllerContext.HttpContext.Request.Form.AllKeys.Contains(this.Name + ".x")
                    && controllerContext.HttpContext.Request.Form.AllKeys.Contains(this.Name + ".y");
            }
            
            return retu;
        }
    }
}