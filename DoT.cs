using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    public delegate string DoTInterpolateFunc(object value);
    public delegate string DoTTemplate(object context, DoTInterpolateFunc interpolateFunc = null);

    [Imported]
    [IgnoreNamespace]
    [ScriptName("doT")]
    public static class DoT
    {
        public static DotTemplateSettings TemplateSettings;

        public static extern DoTTemplate Compile(string source);

        public static extern Func<object, string> EncodeHTMLSource();
    }

    [Imported]
    [Serializable]
    public class DotTemplateSettings
    {
        public DoTInterpolateFunc InterpolateFunc;
    }
}
