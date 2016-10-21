using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Services.Attributes
{
    /// <summary>
    /// APIControllerInfo attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class APIControllerInfoAttribute : Attribute
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public string Group { get; set; } 

        /// <summary>
        /// Description.
        /// </summary>
        public string Description{get;set;}

        /// <summary>
        /// Order.
        /// </summary>
        public int Order { get; set; }        

        /// <summary>
        /// APIControllerInfoAttribute constructor.
        /// </summary>
        public APIControllerInfoAttribute() { }

        /// <summary>
        /// APIControllerInfoAttribute constructor.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="group">Group.</param>
        public APIControllerInfoAttribute(string name, string description, string group)
        {            
            this.Name = Name;
            this.Description = description;
            this.Group = group;
        }
    }
}
