﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accela.Apps.Shared.Web.BaseClasses
{
    public abstract class EditModelBase<T>
    {
        public T Data { get; set; }

        public abstract void InitNewData();

        public abstract void InitEditData(Guid id);

        public abstract void SaveData();
    }
}