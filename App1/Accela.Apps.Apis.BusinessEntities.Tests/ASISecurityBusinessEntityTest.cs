using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Accela.Apps.Apis.BusinessEntities.Tests
{
    [TestFixture]
    public class ASISecurityBusinessEntityTest
    {
        [Test]
        public void TestAttachColumnsAndRows()
        {
            ASISecurityBusinessEntity entity = new ASISecurityBusinessEntity(null, null);
            List<AdditionalTableModel> asits = null;
            List<AdditionalTableModel> referenceASITs = null;
            try
            {
                // both empty
                asits = new List<AdditionalTableModel>();
                referenceASITs = new List<AdditionalTableModel>();
                entity.AttachColumnsAndRows(asits, referenceASITs);

                TestNewASIT(entity);
                TestUpdateASIT(entity);
                TestUpdateReadonlyASIT(entity);
            }
            catch (Exception e)
            {
                Assert.Fail("unexpected exception", e);
            }
        }

        private void TestNewASIT(ASISecurityBusinessEntity entity)
        {
            List<AdditionalTableModel> asits = new List<AdditionalTableModel>();
            List<AdditionalTableModel> referenceASITs = new List<AdditionalTableModel>();
            // input table with empty reference table
            AdditionalTableModel table = new AdditionalTableModel();
            table.Columns = new List<AdditionalColumnModel>();
            table.Rows = new List<AdditionalRowModel>();

            AdditionalColumnModel col = new AdditionalColumnModel()
            {
                Identifier = "Name",
                Security = "F",
                Type = "Text"
            };
            table.Columns.Add(col);

            AdditionalRowModel row = new AdditionalRowModel()
            {
                Identifier = "row-1",
                Action = "Update",
                Values = new List<AdditionalValueModel>()
            };
            
            AdditionalValueModel value = new AdditionalValueModel()
            {
                Identifier = "Name",
                Value = "UT - name"
            };
            row.Values.Add(value);
            table.Rows.Add(row);

            asits.Add(table);

            table = new AdditionalTableModel();
            // input table with empty reference table
            table.Columns = new List<AdditionalColumnModel>();

            col = new AdditionalColumnModel()
            {
                Identifier = "Name",
                Security = "F",
                Type = "Text",
                DefaultValue = "Name Default"
            };
            table.Columns.Add(col);
            referenceASITs.Add(table);

            entity.AttachColumnsAndRows(asits, referenceASITs);
            Assert.AreEqual(asits[0].Rows.Count, 1);
            Assert.AreEqual(asits[0].Rows[0].Values[0].Value, "UT - name");
        }

        private void TestUpdateASIT(ASISecurityBusinessEntity entity)
        {
            List<AdditionalTableModel> asits = new List<AdditionalTableModel>();
            List<AdditionalTableModel> referenceASITs = new List<AdditionalTableModel>();
            // input table with empty reference table
            AdditionalTableModel table = new AdditionalTableModel();
            table.Columns = new List<AdditionalColumnModel>();
            AdditionalColumnModel col = new AdditionalColumnModel()
            {
                Identifier = "Name",
                Security = "F",
                Type = "Text"
            };
            table.Columns.Add(col);

            table.Rows = new List<AdditionalRowModel>();
            
            AdditionalRowModel row = new AdditionalRowModel()
            {
                Identifier = "row-1",
                Values = new List<AdditionalValueModel>()
            };
            AdditionalValueModel value = new AdditionalValueModel()
            {
                Identifier = "Name",
                Value = "UT - name"
            };
            row.Values.Add(value);
            table.Rows.Add(row);


            row = new AdditionalRowModel()
            {
                Identifier = "row-2",
                Values = new List<AdditionalValueModel>(),
                Action = "New"
            };
            value = new AdditionalValueModel()
            {
                Identifier = "Name",
                Value = "UT - name2"
            };
            row.Values.Add(value);
            table.Rows.Add(row);

            asits.Add(table);

            table = new AdditionalTableModel();
            // input table with empty reference table
            table.Columns = new List<AdditionalColumnModel>();

            col = new AdditionalColumnModel()
            {
                Identifier = "Name",
                Security = "F",
                Type = "Text",
                DefaultValue = "Name Default"
            };
            table.Columns.Add(col);

            table.Rows = new List<AdditionalRowModel>();
            row = new AdditionalRowModel()
            {
                Identifier = "row-1",
                Values = new List<AdditionalValueModel>()
            };
            value = new AdditionalValueModel()
            {
                Identifier = "Name",
                Value = "Existing Value"
            };
            row.Values.Add(value);
            table.Rows.Add(row);
            referenceASITs.Add(table);

            entity.AttachColumnsAndRows(asits, referenceASITs);
            Assert.AreEqual(asits[0].Rows.Count, 2);
            Assert.AreEqual(asits[0].Rows[0].Values[0].Value, "UT - name");
            Assert.AreEqual(asits[0].Rows[1].Values[0].Value, "UT - name2");
        }

        private void TestUpdateReadonlyASIT(ASISecurityBusinessEntity entity)
        {
            List<AdditionalTableModel> asits = new List<AdditionalTableModel>();
            List<AdditionalTableModel> referenceASITs = new List<AdditionalTableModel>();
            // input table with empty reference table
            AdditionalTableModel table = new AdditionalTableModel();
            table.Columns = new List<AdditionalColumnModel>();
            AdditionalColumnModel col = new AdditionalColumnModel()
            {
                Identifier = "Name",
                Security = "R",
                Type = "Text"
            };
            table.Columns.Add(col);

            table.Rows = new List<AdditionalRowModel>();

            AdditionalRowModel row = new AdditionalRowModel()
            {
                Identifier = "row-1",
                Action = "Update",
                Values = new List<AdditionalValueModel>()
            };
            AdditionalValueModel value = new AdditionalValueModel()
            {
                Identifier = "Name",
                Value = "UT - name"
            };
            row.Values.Add(value);
            table.Rows.Add(row);

            row = new AdditionalRowModel()
            {
                Identifier = "row-2",
                Action = "Delete",
                Values = new List<AdditionalValueModel>()
            };
            value = new AdditionalValueModel()
            {
                Identifier = "Name",
                Value = "UT - name2"
            };
            row.Values.Add(value);
            table.Rows.Add(row);

            asits.Add(table);

            table = new AdditionalTableModel();
            // input table with empty reference table
            table.Columns = new List<AdditionalColumnModel>();

            col = new AdditionalColumnModel()
            {
                Identifier = "Name",
                Security = "R",
                Type = "Text",
                DefaultValue = "Name Default"
            };
            table.Columns.Add(col);

            table.Rows = new List<AdditionalRowModel>();
            row = new AdditionalRowModel()
            {
                Identifier = "row-1",
                Values = new List<AdditionalValueModel>()
            };
            value = new AdditionalValueModel()
            {
                Identifier = "Name",
                Value = "Existing Value"
            };
            row.Values.Add(value);
            table.Rows.Add(row);
            row = new AdditionalRowModel()
            {
                Identifier = "row-2",
                Values = new List<AdditionalValueModel>(),
                Action = "New"
            };
            value = new AdditionalValueModel()
            {
                Identifier = "Name",
                Value = "Existing Value2"
            };
            row.Values.Add(value);
            table.Rows.Add(row);
            referenceASITs.Add(table);

            entity.AttachColumnsAndRows(asits, referenceASITs);
            Assert.AreEqual(asits[0].Rows.Count, 2);
            Assert.AreEqual(asits[0].Rows[0].Values[0].Value, "Existing Value");
            Assert.AreEqual(asits[0].Rows[1].Values[0].Value, "Existing Value2");
        }
    }
}
