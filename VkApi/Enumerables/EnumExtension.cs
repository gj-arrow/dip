﻿using System;
using System.ComponentModel;

namespace VkApi.Enumerables
{
    public static class EnumExtension
    {
        public static string GetStringMapping(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
