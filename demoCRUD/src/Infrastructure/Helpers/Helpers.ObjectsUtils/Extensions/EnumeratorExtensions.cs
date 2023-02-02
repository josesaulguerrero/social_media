using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Helpers.ObjectsUtils.Extensions
{
    /// <summary>
    /// EnumeratorExtensions
    /// </summary>
    public static class EnumeratorExtensions
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns></returns>
        public static string GetDescription<T>(this T enumeration) where T : IConvertible
        {
            if (enumeration is Enum)
            {
                Type type = enumeration.GetType();
                Array values = Enum.GetValues(type);

                foreach (int value in values)
                {
                    if (value == enumeration.ToInt32(CultureInfo.InvariantCulture))
                    {
                        System.Reflection.MemberInfo[] publicMemberForValue = type.GetMember(type.GetEnumName(value));

                        if (publicMemberForValue[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() is DescriptionAttribute descriptionAttribute)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        ///   Converts to enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">value.</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}