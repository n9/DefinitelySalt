using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Html;

namespace DefinitelySalt
{
    [Serializable]
    public class GlobalizeCulture
    {
        public string Name;
        public string EnglishName;
        public string NativeName;
        public bool IsRtl;
        public string Language;
        public GlobalizeNumberFormat NumberFormat;
        public JsDictionary<string, GlobalizeCalendar> Calendars;
        public JsDictionary<string, string> Messages;

    }

    [Serializable]
    public class GlobalizeNumberFormat
    {
    }

    [Serializable]
    public class GlobalizeCalendar
    {
    }
    
    [Imported]
    [IgnoreNamespace]
    public static class Globalize
    {
        [InlineCode("{$DefinitelySalt.Globalize}.culture()")]
        public static GlobalizeCulture GetCulture() { return null; }

        [InlineCode("{$DefinitelySalt.Globalize}.culture({selector})")]
        public static void SetCulture(string selector) { }

        public static int ParseInt(string text, int radix = 10, string cultureSelector = null) { return default(int); }

        public static double ParseFloat(string text, int radix = 10, string cultureSelector = null) { return default(double); }

        public static DateTime ParseDate(string text, string format = null, string cultureSelector = null) { return default(DateTime); }

        public static DateTime ParseDate(string text, string[] formats, string cultureSelector = null) { return default(DateTime); }
    }
}
