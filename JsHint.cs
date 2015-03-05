using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Imported]
    [Serializable]
    public class JsHintOptions
    {
        // TODO
    }

    [Imported]
    [Serializable]
    public class JsHintError
    {
        public string Scope;
        public string Raw;
        public string Code;
        public string Reason;
        public int Line;
        public int Character;
    }

    [Imported]
    [Serializable]
    public class JsHintUndef
    {
        [ScriptName("0")]
        public IJsHintScope Scope;

        [ScriptName("1")]
        public string Code;

        [ScriptName("2")]
        public IJsHintToken Token;

        [ScriptName("3")]
        public string Name;
    }

    [Imported]
    [Serializable]
    public class JsHintImplied
    {
        public string Name;
        public int[] Line;
    }

    [Imported]
    [Serializable]
    public class JsHintUnused
    {
        public string Name;
        public int Line;
        public int Character;
    }

    [Imported]
    public interface IJsHintScope
    {
        // ...
    }

    [Imported]
    public interface IJsHintToken
    {
        [ScriptName("raw_text")]
        string RawText { get; }
        string Value { get; }
        int From { get; }
        int Line { get; }
        int Character { get; }
        // ...
    }

    [Imported]
    public interface IJsHintData
    {
        JsHintError[] Errors { get; }
        object[] Functions { get; }
        string[] Globals { get; }
        JsHintImplied[] Implies { get; }
        JsDictionary<string, object> Options { get; }
        JsHintUnused[] Unused { get; }
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("JSHINT")]
    public static class JsHint
    {
        [ScriptName("")]
        extern public static bool Call(string code, JsHintOptions options, JsDictionary<string, bool> globals);

        public static JsHintError[] Errors;
        public static JsHintUndef[] Undefs;

        extern public static IJsHintData Data();
    }
}
