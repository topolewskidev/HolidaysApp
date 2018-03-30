using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UrlopowaTortilla.Helpers
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetConcreteChildren(this Type type)
        {
            return Assembly.GetAssembly(type).GetTypes().Where(t =>
                t.IsClass
                && !t.IsAbstract
                && type.IsAssignableFrom(t));
        }

        public static Type GetConcreteChild(this Type type, string name)
        {
            return type.GetConcreteChildren().Single(t => t.Name == name);
        }
    }
}