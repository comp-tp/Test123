using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Azure.Tables
{

    public static class DynamicTableEntityConverter<T> where T : class, Accela.Infrastructure.Tables.ITableEntity
    {
        public static Microsoft.WindowsAzure.Storage.Table.ITableEntity ToAzureTableEntity(T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            string dynamicClassName = string.Format("{0}-{1}", source.GetType().Name, source.GetType().GetHashCode());
            Type dynamicType = GetOrCreateDynamicType(dynamicClassName, source, typeof(AzureTableEntity));

            // Azure table entity which base class is AzureTableEntity
            var targetObj = Activator.CreateInstance(dynamicType);

            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = dynamicType.GetProperties();

            foreach (var p in sourceProperties)
            {
                object value = p.GetValue(source);

                var properties = dynamicType.GetProperties().Where(t => t.Name == p.Name).ToList();

                // if exists base class, it has 2 properties
                foreach(var pp in properties)
                {
                    pp.SetValue(targetObj, value);
                }
            }

            return targetObj as Microsoft.WindowsAzure.Storage.Table.ITableEntity;
        }

        public static T ToITableEntity(Microsoft.WindowsAzure.Storage.Table.ITableEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            string dynamicClassName = string.Format("{0}-{1}", typeof(T).Name, source.GetType().GetHashCode());
            Type dynamicType = GetOrCreateDynamicType(dynamicClassName, source, typeof(T));

            // Accela.Infrastructure.Tables.ITableEntity
            var targetObj = Activator.CreateInstance(dynamicType);

            var sourceProperties = source.GetType().GetProperties();

            foreach (var p in sourceProperties)
            {
                object value = p.GetValue(source);

                var properties = dynamicType.GetProperties().Where(t => t.Name == p.Name).ToList();

                // if exists base class, it has 2 properties
                foreach (var pp in properties)
                {
                    pp.SetValue(targetObj, value);
                }
            }

            return targetObj as T;
        }

        public static T ToITableEntity(Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            string dynamicClassName = string.Format("{0}-{1}", typeof(T).Name, source.GetType().GetHashCode());
            Type dynamicType = GetOrCreateDynamicType(dynamicClassName, source, typeof(T));

            // Accela.Infrastructure.Tables.ITableEntity
            var targetObj = Activator.CreateInstance(dynamicType);

            var sourceProperties = source.GetType().GetProperties();

            foreach (var p in sourceProperties)
            {
                if (p.Name == "Item")
                {
                    continue;
                }

                if (p.Name == "Properties")
                {
                    foreach(var dp in source.Properties)
                    {
                        var properties = dynamicType.GetProperties().Where(t => t.Name == dp.Key).ToList();

                        // if exists base class, it has 2 properties
                        foreach (var pp in properties)
                        {
                            pp.SetValue(targetObj, dp.Value.PropertyAsObject);
                        }
                    }
                }
                else
                {
                    object value = p.GetValue(source);

                    var properties = dynamicType.GetProperties().Where(t => t.Name == p.Name).ToList();

                    // if exists base class, it has 2 properties
                    foreach (var pp in properties)
                    {
                        pp.SetValue(targetObj, value);
                    }
                }
            }

            return targetObj as T;
        }


        private static IDictionary<string, Type> _dynamicTypes = new Dictionary<string, Type>();

        private static Type GetOrCreateDynamicType(string dynamicClassName, object entity, Type baseClass)
        {
            Type result = null;
        
            if (_dynamicTypes.ContainsKey(dynamicClassName))
            {
                result = _dynamicTypes[dynamicClassName];
            }

            if (result == null)
            {
                result = CompileResultType(dynamicClassName, entity.GetType().GetProperties(), baseClass);

                // cache type
                _dynamicTypes[dynamicClassName] = result;
            }

            if (result == null)
            {
                throw new Exception(String.Format("Create dynamic type - '{0}' failed.", dynamicClassName));
            }

            return result;
        }

        private static Type CompileResultType(string dynamicClassName, PropertyInfo[] propertyInfos, Type baseClass)
        {
            TypeBuilder tb = GetTypeBuilder(dynamicClassName, baseClass);

            ConstructorBuilder constructor = tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);

            foreach (var field in propertyInfos)
            {
                CreateProperty(tb, field.Name, field.PropertyType);
            }

            Type objectType = tb.CreateType();
            return objectType;
        }

        private static TypeBuilder GetTypeBuilder(string dynamicClassName, Type baseClass)
        {
            var assembleName = "Accela.Infrastructure.Azure.DynamicObjects";
            var an = new AssemblyName(assembleName);
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicObjectsModel");
            TypeBuilder tb = moduleBuilder.DefineType(dynamicClassName
                                , TypeAttributes.Public |
                                TypeAttributes.Class |
                                TypeAttributes.AutoClass |
                                TypeAttributes.AnsiClass |
                                TypeAttributes.BeforeFieldInit |
                                TypeAttributes.AutoLayout
                                , baseClass);
            return tb;
        }

        private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
        {
            FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
            MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }
    }
}
