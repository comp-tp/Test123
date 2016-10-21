using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Accela.Apps.Shared.Ioc
{
    public static class IocRegisterationHelper
    {
        public static Dictionary<Type, Type> GetRegisterationTypes(Type serviceBaseType, Assembly candicateAssembly)
        {
            var registrations = (from type in candicateAssembly.GetExportedTypes()
                                 let interfaces = type.GetInterfaces()
                                 where type.IsClass
                                 && !type.IsAbstract
                                 && interfaces.Any(i => i.IsAssignableFrom(serviceBaseType))
                                 select new
                                 {
                                     Interface = interfaces.First(),
                                     Implementation = type
                                 }).Distinct().ToDictionary(p => p.Implementation, p => p.Interface);
            return registrations;
        }

        public static IEnumerable<Type> GetImplementationTypes(Type serviceBaseType, Assembly candicateAssembly)
        {
            var registrations = (from type in candicateAssembly.GetExportedTypes()
                                 let interfaces = type.GetInterfaces()
                                 where type.IsClass
                                 && !type.IsAbstract
                                 && (interfaces.Any(i => i.IsAssignableFrom(serviceBaseType))
                                    || IsAssignableToGenericType(type, serviceBaseType))
                                 select type).AsEnumerable();
            return registrations;
        }

        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            bool result = false;

            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                {
                    result = true;
                    break;
                }
            }

            if (!result && givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                result = true;
            }

            if (!result)
            {
                Type baseType = givenType.BaseType;

                if (baseType != null)
                {
                    result = IsAssignableToGenericType(baseType, genericType);
                }
            }

            return result;
        }
    }
}
