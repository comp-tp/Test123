using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Accela.Apps.GeoServices.Geocode.Parser
{
    public class UsaAddressParseResult
    {
        private string streetLine;

        internal UsaAddressParseResult(Dictionary<string, string> fields)
        {
            InitInstanceFields(fields);
        }

        public string HouseNumber
        {
            get;
            private set;
        }

        public string StreetPrefixDirection
        {
            get;
            private set;
        }

        public string StreetDirection
        {
            get;
            private set;
        }

        public string StreetName
        {
            get;
            private set;
        }

        public string StreetType
        {
            get;
            private set;
        }

        public string UnitType
        {
            get;
            private set;
        }

        public string UnitNumber
        {
            get;
            private set;
        }

        public string City
        {
            get;
            private set;
        }

        public string State
        {
            get;
            private set;
        }

        public string Zip
        {
            get;
            private set;
        }

        public string StreetLine
        {
            get
            {
                if (this.streetLine == null)
                {
                    var streetLine = string.Join(
                        " ",
                        new[] {
                            this.HouseNumber,
                            this.StreetPrefixDirection,
                            this.StreetName,
                            this.StreetType,
                            this.StreetDirection,
                            this.UnitType,
                            this.UnitNumber
                    });
                    streetLine = Regex
                        .Replace(streetLine, @"\ +", " ")
                        .Trim();
                    return streetLine;
                }

                return this.streetLine;
            }

            private set
            {
                this.streetLine = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}{2}{3}",
                this.StreetLine,
                !String.IsNullOrWhiteSpace(this.City) ? String.Format("; {0}", this.City) : String.Empty,
                !String.IsNullOrWhiteSpace(this.State) ? String.Format(", {0}", this.State) : String.Empty,
                !String.IsNullOrWhiteSpace(this.Zip) ? String.Format(" {0}", this.Zip) : String.Empty
                );
        }

        private void InitInstanceFields(Dictionary<string, string> fields)
        {
            if (fields == null)
            {
                throw new ArgumentNullException("fields");
            }

            var type = this.GetType();
            foreach (var pair in fields)
            {
                var bindingFlags =
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.IgnoreCase;
                var propertyInfo = type.GetProperty(pair.Key, bindingFlags);
                if (propertyInfo != null)
                {
                    var methodInfo = propertyInfo.GetSetMethod(true);
                    if (methodInfo != null)
                    {
                        methodInfo.Invoke(this, new[] { pair.Value });
                    }
                }
            }
        }
    }
}
