using Accela.Core.Logging.Util;
using NUnit.Framework;
using System;
using System.Linq;

namespace Accela.Core.Logging.Test
{
    public class SensitiveDataFilterTest
    {
        [Test]
        public void Filter()
        {
            //case 1:access_token
            string content = "{\"access_token\":\"LL7Eo1H5ggafdsgfdsgfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jweffgeigfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jweffgfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jweffgfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jwefftfdsgewtfdtregdasgdhgjukjhcba0Md1y4CZilbm9upYIzxatHrMgiIqvEBmjFfAP8IM6kkw5pEUuo1\",\"refresh_token\":\"TRXB!IAAAAPV2kxVgL8q1Q3MV0XloYpkRapyEA\"}";
            string result = SensitiveDataFilter.Filter(content);
            string expected = "{\"access_token\":\"***dfdsafdvctekuifgdewq32765jweffgeigfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jweffgfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jweffgfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jwefftfdsgewtfdtregdasgdhgjukjhcba0Md1y4CZilbm9upYIzxatHrMgiIqvEBmjFfAP8IM6kkw5pEUuo1\",\"refresh_token\":\"***RapyEA\"}";
            Assert.AreEqual(expected, result);

            // case 1.2: AA token
            content = "token=21345678901234567890";
            result = SensitiveDataFilter.Filter(content);
            expected = "token=21***";
            Assert.AreEqual(expected, result);

            // case 1.3: access_token
            content = "\"access_token\":\"qySCD01xeaIbdwcT2EiwjPmsFW98XefgRQFdUsUydbgpYKD4i3ivaG1TNZyvd73zixIUxA2vkerhPfVDHGuiLTZmL_vOpGspvk74xdD1ZiN2gfLMj0oxtw6R60U1\"";
            result = SensitiveDataFilter.Filter(content);
            expected = "\"access_token\":\"***RQFdUsUydbgpYKD4i3ivaG1TNZyvd73zixIUxA2vkerhPfVDHGuiLTZmL_vOpGspvk74xdD1ZiN2gfLMj0oxtw6R60U1\"";
            Assert.AreEqual(expected, result);

            // case 3: client_secret
            content = "grant_type=password&client_id=635571314934393480&client_secret=24c113553a5844fb8950ea8db9a9b961&agency_name=BPTDEV";
            result = SensitiveDataFilter.Filter(content);
            expected = "grant_type=password&***d=635571314934393480&client_secret=***&agency_name=BPTDEV";
            Assert.AreEqual(expected, result);

            // case 4: x-accela-subsystem-accesskey ==> no generic handling; handle from subsystem API handler
            //content = "x-accela-subsystem-accesskey=24c113553a5844fb8950ea8db9a9b961&agency_name=BPTDEV";
            //result = SensitiveDataFilter.Filter(content);
            //expected = "x-accela-subsystem-accesskey=***&agency_name=BPTDEV";
            //Assert.AreEqual(expected, result);


            // case 5: Authorization ==> no generic handling; handle from subsystem API handler
            //content = "Authorization:qySCD01xeaIbdwcT2EiwjPmsFW98XefgRQFdUsUydbgpYKD4i3ivaG1TNZyvd73zixIUxA2vkerhPfVDHGuiLTZmL_vOpGspvk74xdD1ZiN2gfLMj0oxtw6R60U1";
            //result = SensitiveDataFilter.Filter(content);
            //expected = "Authorization:***xdD1ZiN2gfLMj0oxtw6R60U1";
            //Assert.AreEqual(expected, result);


            // case 3: password
            content = "password=admin12345&username=admin&scope=records settings inspections agencies";
            result = SensitiveDataFilter.Filter(content);
            expected = "password=***45&username=admin&scope=records settings inspections agencies";
            Assert.AreEqual(expected, result);

            // case 4: creditcard
            content = "\"creditcard\":\"4111123456781111\"";
            result = SensitiveDataFilter.Filter(content);
            expected = "\"creditcard\":\"***\"";
            Assert.AreEqual(expected, result);

            // case 5: SSN
            content = "\"socialSecurityNumber\":\"12345678\"";
            result = SensitiveDataFilter.Filter(content);
            expected = "\"socialSecurityNumber\":\"***\"";
            Assert.AreEqual(expected, result);

            // case 6: driver license
            content = "\"driverLicenseNumber\":\"12345678\"";
            result = SensitiveDataFilter.Filter(content);
            expected = "\"driverLicenseNumber\":\"***\"";
            Assert.AreEqual(expected, result);

            content = "\"driverLicenseNumber\":\"12345678\",\"driverLicenseNumber\":\"12345678\"";
            result = SensitiveDataFilter.Filter(content);
            expected = "\"driverLicenseNumber\":\"***\",\"driverLicenseNumber\":\"***\"";
            Assert.AreEqual(expected, result);

            content = "\"firstName\":\"Tom\",\"driverLicenseNumber\":\"12345678\",\"address\":\"San Ramon\"";
            result = SensitiveDataFilter.Filter(content);
            expected = "\"firstName\":\"Tom\",\"driverLicenseNumber\":\"***\",\"address\":\"San Ramon\"";
            Assert.AreEqual(expected, result);

            // case 7: <pplicationState>
            content = "<ApplicationState>54307762140710663665219349740566601307740601047036256022836973260170925452013419772514840062034091354735444605353655550936758951</ApplicationState>";
            result = SensitiveDataFilter.Filter(content);
            expected = "<ApplicationState>***</ApplicationState>"; ;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaskString()
        {
            // case 1: key at begin
            string content = "password=admin&username=admin&scope=records settings inspections agencies";
            var result = SensitiveDataFilter.MaskString(content, "password", 5);
            var expected = "password=***&username=admin&scope=records settings inspections agencies";
            Assert.AreEqual(expected, result);

            // case 2: key in middle
            content = "username=admin&password=admin&scope=records settings inspections agencies";
            result = SensitiveDataFilter.MaskString(content, "password", 5);
            expected = "username=admin&password=***&scope=records settings inspections agencies";
            Assert.AreEqual(expected, result);

            // case 3: key at end
            content = "username=admin&scope=records settings inspections agencies&password=admin";
            result = SensitiveDataFilter.MaskString(content, "password", 5);
            expected = "username=admin&scope=records settings inspections agencies&password=***";
            Assert.AreEqual(expected, result);

            // case 4: Json Format
            content = "{\"password\":\"11111\",\"userName\":\"testc\"}";
            result = SensitiveDataFilter.MaskString(content, "password", 5,3);
            expected = "{\"password\":\"***\",\"userName\":\"testc\"}"; 
            Assert.AreEqual(expected, result);

            // key doesn't exist
            content = "username=admin&scope=records settings inspections agencies&password=admin";
            result = SensitiveDataFilter.MaskString(content, "NotExist", 5);
            Assert.AreEqual(content, result);

            // key at 2 places
            content = "password=admin&scope=records settings inspections agencies&password=admin";
            result = SensitiveDataFilter.MaskString(content, "password", 5);
            expected = "password=***&scope=records settings inspections agencies&password=***";
            Assert.AreEqual(expected, result);

            // key at end 
            content = "username=admin&scope=records settings inspections agencies&password";
            result = SensitiveDataFilter.MaskString(content, "password", 5);
            expected = "username=admin&scope=records settings inspections agencies&password";
            Assert.AreEqual(expected, result);

            // skip mask
            content = "username=admin&scope=records settings inspections agencies&password=admin";
            result = SensitiveDataFilter.MaskString(content, "password", 6, 100);
            expected = "username=admin&scope=records settings inspections agencies&password=admin";
            Assert.AreEqual(expected, result);

            // invalid maskstring parameter
            content = "username=admin&scope=records settings inspections agencies&password=admin";
            result = SensitiveDataFilter.MaskString(content, "password", 100);
            expected = "username=admin&scope=records settings inspections agencies&password=***";
            Assert.AreEqual(expected, result);

            content = "username=admin&scope=records settings inspections agencies&password=admin12345678";
            result = SensitiveDataFilter.MaskString(content, "password", 10);
            expected = "username=admin&scope=records settings inspections agencies&password=***678";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Filter_ShouldLess_1s_for_1K()
        {
            string content = @"{""access_token"":""LL7Eo1H5ggafdsgfdsgfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jweffgeigfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jweffgfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jweffgfdsgfdsgfsgwqdfdsafdvctekuifgdewq32765jwefftfdsgewtfdtregdasgdhgjukjhcba0Md1y4CZilbm9upYIzxatHrMgiIqvEBmjFfAP8IM6kkw5pEUuo1TRXB!IAAAAPV2kxVgL8q1Q3MV0XloYpkRapyEA}
                                password=admin&username=admin&scope=records settings inspections agencies get_resources
get_oauth2_token
get_addresses
get_address
get_app_data
update_app_data
delete_app_data
geocode_search_records
get_assets
get_asset
create_asset
get_condition_assessments
search_contacts
get_contacts
get_document
get_thumbnail
get_gis_settings
search_inspections
get_inspections
get_inspection
reschedule_inspection
reassign_inspection
create_inspection
get_inspector
reverse_geocode
search_agencies_by_geo
get_owners
search_parcels
get_parcels
get_parcel
get_parcel_owners
get_parcel_addresses
search_records
get_records
get_record
get_record_owners
get_record_contacts
update_record
create_record
get_record_addresses
get_record_documents
create_record_document
get_record_asis
get_record_asits
get_record_parcels
get_record_costs
get_record_parts
get_related_records
get_record_conditions
get_record_inspections
get_record_assets
get_record_comments
get_record_workflow_tasks
update_record_workflow_task
get_record_location
get_record_workorder_tasks
get_record_condition_summary
get_record_inspection_summary
get_record_workflow_summary
get_record_fee_summary
get_record_contact_summary
get_record_project_informations
create_record_user_comment
get_record_user_comments
create_record_vote
get_record_votes
get_record_user_activities_summary
get_ref_street_prefixes
get_ref_asset_statuses
get_ref_asset_types
get_ref_asset_unit_types
get_ref_asset_asis
get_ref_asset_asits
get_ref_checklist_items
get_ref_checklists
get_ref_standard_comments
get_ref_standard_comment_groups
get_ref_modules
get_ref_departments
get_ref_staffs
get_ref_work_order_templates
get_ref_contact_types
get_ref_document_types
get_ref_inspection_groups
get_ref_inspection_types
get_ref_inspectors
get_ref_inspection_checklist_groups
get_ref_record_types
get_ref_record_type_asis
get_ref_record_type_asits
get_ref_record_type_statuses
get_ref_record_priorities
get_app_settings
cancel_inspection
get_available_inspection_dates
get_stat_mostactive_apps
get_stat_mostactive_agencies
update_inspection_comments
get_record_asi_drilldown
update_announcements_read
get_settings_agencies
search_contacts
update_subscription
get_contacts_customforms
civichero_get_my_record
get_part_locations
get_inspection_checklists
update_record_workflow_task_customforms
get_settings_cost_unit_types
update_contacts_addresses
a311citizen_get_user_comment
get_ref_record_type
delete_record_documents
upload_checklistitem_documents
delete_records_costs
a311citizen_unfollow_record
inspectorapp_get_record_asi_drilldown_parent
get_settings_part_types
result_inspection
add_contact_conditions
get_assessment
get_inspector
a311citizen_create_record
get_ref_asi_drilldown
get_inspection_checklist_items
void_invoice
update_citizenaccess_citizens_invitation
get_record_customtables
get_record_customtable
update_record_customtables
get_record_customtables_meta
get_record_customtable_meta
get_record_customforms
get_record_customforms_meta
update_record_customforms
get_record_customform_meta
get_settings_drilldown
get_record_parcels
create_record_parcels
update_record_parcel
delete_record_parcels
get_parcel_addresses
get_parcel_owners
get_parcels
get_parcel
get_record_additional
update_record_additional
get_record_comments
update_record_comment
delete_record_comments
create_record_comments
create_record
create_partial_record
finalize_record
get_record
get_records
get_my_records
get_record_inspection_types
get_record_inspections
get_record_document_categories
update_record
get_settings_record_type_customform
get_settings_record_type_customtable
get_settings_construction_types
get_settings_record_types
get_record_fees
create_report
get_settings_report_categories
get_settings_report_definitions
get_settings_report_definition
run_emse_script
get_inspection_timeaccounting
create_inspection_timeaccounting
delete_inspection_timeaccounting
update_inspection_timeaccounting
get_record_workflow_tasks
get_record_workflow_task
update_record_workflow_task
get_my_workflow_tasks
global_search
search_inspections
search_records
search_owners
search_professionals
search_parcels
search_addresses
download_document
get_document
get_settings_document_categories
create_record_documents
get_record_documents
delete_record_document
get_settings_condition_types
get_settings_condition_statuses
get_settings_condition_approval_statuses
get_settings_condition_priorities
get_inspection_condition_approvals
get_inspection_condition_approval
create_inspection_condition_approvals
update_inspection_condition_approval
delete_inspection_condition_approvals
get_inspection_conditions
get_inspection_condition
create_inspection_conditions
update_inspection_condition
delete_inspection_conditions
get_inspection_condition_histories
create_record_condition_approvals
delete_record_condition_approvals
get_record_condition_approvals
get_record_condition_approval
update_record_condition_approval
get_record_conditions
get_record_condition
create_record_conditions
update_record_condition
delete_record_conditions
get_condition_approvals_standard
get_conditions_standard
get_record_contacts
get_settings_contact_types
get_settings_contact_relations
get_settings_contact_salutations
get_settings_contact_races
get_settings_contact_preferredChannels
get_contact
create_contacts
update_contact
delete_contacts
create_contact_addresses
get_contact_addresses
create_record_contacts
update_record_contact
delete_record_contacts
get_owners
get_owner
get_record_owners
create_record_owners
update_record_owner
delete_record_owners
get_record_professionals
create_record_professionals
delete_record_professionals
update_record_professional
get_settings_professional_types
get_settings_professional_license_boards
get_settings_professional_salutations
get_professional
get_professionals
get_professional_records
create_record_related
delete_record_related
get_record_related
get_settings_departments
get_settings_department_staffs
get_settings_record_statuses
get_settings_priorities
get_inspection_related
create_inspection_related
delete_inspection_related
get_settings_inspection_grades
get_settings_inspection_statuses
get_inspection_comments
get_inspection
get_inspection_histories
get_inspection_checklists
create_inspection_checklists
get_inspection_checklist_items
delete_inspection_checklists
get_inspection_checklist_histories
get_inspection_checklist_item_histories
update_inspection_checklist_items
get_inspection_checklist_item_documents
create_inspection_checklist_item_document
get_inspection_documents
create_inspection_documents
delete_inspection_documents
schedule_inspection
get_inspection_available_dates
schedule_pending_inspection
reschedule_inspection
cancel_inspection
update_inspection
result_inspection
assign_inspections
delete_inspections
get_inspections
get_settings_inspection_checklists
get_settings_inspection_checklist
get_settings_checklist_item_customtable
get_settings_checklist_item_customform
get_settings_checklist_groups
get_inspection_checklist_item_customforms
update_inspection_checklist_item_customforms
get_inspection_checklist_item_customforms_meta
get_inspection_checklist_item_customform_meta
get_inspection_checklist_item_customtables_meta
get_inspection_checklist_item_customtable_meta
update_inspection_checklist_item_customtables
get_inspection_checklist_item_customtables
get_inspection_checklist_item_customtable
get_record_addresses
create_record_addresses
update_record_address
";
            //int length = content.Length;  //8117

            var dt1 = DateTime.Now;
            for (int i=0; i < 1000; i++)
            {
                SensitiveDataFilter.Filter(content);
            }

            var dt2 = DateTime.Now;

            double total = (dt2 - dt1).TotalMilliseconds;

            Console.WriteLine("total milliseconds:" + total);
            Assert.Less(total,1000);

            content = GetRandomString(1000);
            dt1 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                SensitiveDataFilter.Filter(content);
            }

            dt2 = DateTime.Now;

            total = (dt2 - dt1).TotalMilliseconds;

            Console.WriteLine("total milliseconds:" + total);
            Assert.Less(total, 1000);

            content = GetRandomString(100 * 1000);
            dt1 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                SensitiveDataFilter.Filter(content);
            }

            dt2 = DateTime.Now;

            total = (dt2 - dt1).TotalMilliseconds;

            Console.WriteLine("total milliseconds:" + total);
            Assert.Less(total, 7000);
        }

        public static string GetRandomString(int length)
        {
            var r = new Random();
            return new String(Enumerable.Range(0, length).Select(n => (Char)(r.Next(32, 127))).ToArray());
        }
    }
}
