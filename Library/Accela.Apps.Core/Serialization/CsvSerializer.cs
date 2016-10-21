using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

//using Accela.Apps.Core.Entity;

namespace Accela.Core.Serialization
{
	public class CsvSerializationIgnoreAttribute : Attribute {}
	
    //public class CsvEntitySerializer
    //{
    //    private const char CSV_DELIMITER = ',';

    //    public string ToString(IEnumerable<IEntity> objects)
    //    {
    //        if (objects == null)
    //            return null;

    //        var list = objects.ToArray();

    //        if (!list.Any())
    //            return null;

    //        var stringBuilder = new StringBuilder();
    //        BuildDocument(list, stringBuilder);
    //        return stringBuilder.ToString();
    //    }

    //    public byte[] ToByteArray(IEnumerable<IEntity> objects)
    //    {
    //        var result = ToString(objects);
    //        return Encoding.ASCII.GetBytes(result);
    //    }

    //    private void BuildDocument(IEntity[] list, StringBuilder stringBuilder)
    //    {
    //        var obj = list.First();
    //        var columnsToIgnore = GetColumnsToIgnore(obj);
    //        var columns = obj.Keys.Where(c => !columnsToIgnore.Contains(c) && c.HasValue()).ToArray();
    //        BuildHeader(columns, stringBuilder);
    //        BuildBody(list, columns, stringBuilder);
    //    }

    //    private static List<string> GetColumnsToIgnore(IEntity obj)
    //    {
    //        var columnsToIgnore = new List<string>();
    //        var objPublicProperties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
    //        foreach (var property in objPublicProperties)
    //        {
    //            if (property.GetCustomAttribute(typeof(CsvSerializationIgnoreAttribute)) != null)
    //            {
    //                columnsToIgnore.Add(property.Name);
    //            }
    //        }
    //        return columnsToIgnore;
    //    }

    //    private static void BuildBody(IEnumerable<IEntity> objects, IEnumerable<string> columns, StringBuilder stringBuilder)
    //    {
    //        foreach (var entity in objects)
    //        {
    //            foreach (var columnName in columns)
    //            {
    //                if (entity.ContainsKey(columnName))
    //                {
    //                    stringBuilder.AppendFormat("\"{0}\"", entity[columnName]);
    //                }
    //                stringBuilder.Append(CSV_DELIMITER);
    //            }
    //            stringBuilder.AppendLine();
    //        }
    //    }

    //    private void BuildHeader(IEnumerable<string> columns, StringBuilder stringBuilder)
    //    {
    //        foreach (var columnName in columns)
    //        {
    //            stringBuilder.Append(columnName);
    //            stringBuilder.Append(CSV_DELIMITER);
    //        }
    //        stringBuilder.AppendLine();
    //    }

    //    public IEnumerable<IEntity> Deserialize(string objects)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
