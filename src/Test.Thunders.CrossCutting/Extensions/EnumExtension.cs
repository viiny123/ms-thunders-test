using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Test.Thunders.CrossCutting.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        var descriptionAttribute =
            enumMember == null
                ? default
                : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
        return
            descriptionAttribute == null
                ? value.ToString()
                : descriptionAttribute.Description;
    }
}