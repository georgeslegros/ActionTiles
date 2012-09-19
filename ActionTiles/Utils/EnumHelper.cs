using System;
using System.Linq;
using System.Reflection;

namespace ActionTiles.Utils
{
    public class EnumHelper
    {
        public static T[] GetEnumValues<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Type '" + type.Name + "' is not an enum");

            return (
                       from field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
                       where field.IsLiteral
                       select (T)field.GetValue(null)
                   ).ToArray();
        }

        public static string[] GetEnumStrings<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Type '" + type.Name + "' is not an enum");

            return (
                       from field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
                       where field.IsLiteral
                       select field.Name
                   ).ToArray();
        }

    }
}