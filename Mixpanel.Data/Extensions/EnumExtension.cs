using System;
using System.ComponentModel;
using System.Linq;

namespace Mixpanel.Data.Facts.Extensions
{
    public static class EnumExtension
    {
        public static string ToDescriptionString(this Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
