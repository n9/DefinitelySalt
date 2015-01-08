using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    public delegate string DoTInterpolateFunc(object value, string param);
    public delegate bool DoTConditionFunc(object value);
    public delegate string DoTBlockFunc(string name, object jsArguments, JsDictionary<string, Function> templateArguments);

    public delegate string DoTTemplate(object context, DoTInterpolateFunc interpolateFunc, DoTConditionFunc conditionFunc, DoTBlockFunc blockFunc);

    [Imported]
    [IgnoreNamespace]
    [ScriptName("doT")]
    public static class DoT
    {
        public static DotTemplateSettings TemplateSettings;

        public static extern DoTTemplate Compile(string source, DotTemplateSettings settings = null);
        public static extern string Template(string source, DotTemplateSettings settings = null);

        public static extern string EncodeHTML(object value);
        public static extern string BlockSplatter(string name, object jsArguments, JsDictionary<string, Function> templateArguments, DoTBlockFunc blockFunction);
    }

    [Imported]
    [Serializable]
    public class DotTemplateSettings
    {
    }
}
