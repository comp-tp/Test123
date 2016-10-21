using System;
using System.Runtime.Serialization;
//using Accela.Azure.Server.Toolkits.Persistences.DBAttribute;

namespace Accela.Apps.Apis.Models.DomainModels.CommentModels
{
    /// <summary>
    /// Comments class
    /// </summary>
    [DataContract]
    public class Comment : ActionDataModel
    {
        #region Fields

        /// <summary>
        /// Comments _fillDate
        /// </summary>
        private string _fillDate;

        /// <summary>
        /// Comments _fillPeopleName
        /// </summary>
        private string _fillPeopleName;

        /// <summary>
        /// Comments _content
        /// </summary>
        private string _content;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the fill date.
        /// </summary>
        [DataMember(Name = "fillDate", EmitDefaultValue = false)]
        public string FillDate
        {
            get
            {
                return _fillDate;
            }
            set
            {
                if (this._fillDate != value)
                {
                    this._fillDate = value;
                    OnValueChanged("FillDate");
                }
            }
        }

        /// <summary>
        /// Gets or sets the fill people name.
        /// </summary>
        [DataMember(Name = "fillPeopleName", EmitDefaultValue = false)]
        public string FillPeopleName
        {
            get
            {
                return _fillPeopleName;
            }
            set
            {
                if (this._fillPeopleName != value)
                {
                    this._fillPeopleName = value;
                    OnValueChanged("FillPeopleName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [DataMember(Name = "content", EmitDefaultValue = false)]
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (this._content != value)
                {
                    this._content = value;
                    OnValueChanged("Content");
                }
            }
        }

        #endregion Properties
    }
}
