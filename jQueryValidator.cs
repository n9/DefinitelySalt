using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace DefinitelySalt
{
    public delegate bool jQueryValidatorMethod(string value, Element element, object @params);

    [BindThisToFirstParameter]
    public delegate void jQueryValidatorInvalidHandler(FormElement form, Event @event, jQueryValidator validator);

    [Imported]
    [Serializable]
    public class jQueryValidatorOptions
    {
        public Action<FormElement> SubmitHandler;
        public jQueryValidatorInvalidHandler InvalidHandler;
    }

    [Imported]
    [ScriptNamespace("$")]
    [ScriptName("validator")]
    public class jQueryValidator
    {
        [IntrinsicProperty]
        public static jQueryValidatorOptions Defaults { get; set; }

        public static void SetDefaults(jQueryValidatorOptions options) { }

        [IntrinsicProperty]
        public static JsDictionary<string, string> Messages { get; set; }

        public static void AddMethod(string name, jQueryValidatorMethod method, string message) { }
        public static void AddClassRules(string name, JsDictionary<string, object> rules) { }
        public static void AddClassRules(JsDictionary<string, JsDictionary<string, object>> namedRules) { }

        public static bool AutoCreateRanges { get; set; }

        public bool Form() { return default(bool); }

        public bool Element(Element element) { return default(bool); }
        public bool Element(string selector) { return default(bool); }

        public int NumberOfInvalids() { return default(int); }
    }

    public static partial class jQueryEx
    {
        [InstanceMethodOnFirstArgument]
        public static jQueryValidator Validate(this jQueryObject jq, jQueryValidatorOptions options = null) { return null; }
    }
}
