using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlQueries
{
    /*
     * Implementation Notes:
      
     From AA version 7.2.0 Hotfix 8 and version 7.1.0 SP13 on, no need to send the EDMS Adapter information to the GovXML
     when downloading the list of document of RECORD and/or INSPECTION and the binary document file.
     
     So we can simply comment the EDMSAdapter property.
    // */
    public class AttachmentsQuery : QueryBase
    {
        /// <summary>
        /// Gets or sets EntityId
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// the field should be "Inspection" or "CAP"
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// Gets or sets the attachment id.
        /// </summary>
        /// <value>
        /// The attachment id.
        /// </value>
        public string AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the EDMS anonymous adapters.
        /// </summary>
        /// <value>
        /// The EDMS anonymous adapters.
        /// </value>
        //public EDMSAdapters EDMSAnonymousAdapters { get; set; }
    }
}
