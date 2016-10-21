
namespace Accela.Apps.Apis.Repositories
{
    public static class Constants
    {

        public const char SEPARATOR = '\f';

        public const int CACHE_EXPIRED_PERIOD = 20;       

        public const string NAMESPACE_ROOT = "accela-apps";        

    }

    public enum EntityTypes
    {
        Inspection,
        InspectionRefType,
        InspectionAttachment,
        StandardCommentGroup,
        StandardComment,
        AssetASIAndASIT,
        DepartmentWithInspector,
        RecordType,
        ASIAndASIT,
        AttachmentDescription,
        AttachmentFileInfo,
        AttachmentFileStream,
        AttachmentFileThumbnailInfo,
        AttachmentFileThumbnailStream,
        RecordSummary,
        AssetType,
        AssetCAType,
        InspectionGroup,
        SystemInspector,
        Checklist,
        ChecklistGroup,
        SystemDepartment,
        SystemContactRole,
        RecordTemplate,
        I18NLanguages
   }
}
