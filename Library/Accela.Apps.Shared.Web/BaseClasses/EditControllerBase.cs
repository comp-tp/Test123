using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accela.Apps.Shared.Web.BaseClasses
{
    public abstract class EditControllerBase<T> : CustomizedControllerBase
    {
        public EditControllerBase()
        {

        }

        public EditControllerBase(IConfigurationReader configurationSettings):base(configurationSettings)
        {

        }
        public abstract ActionResult SaveAction(T viewModel);
    }
}