using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("jade")]
    public static class Jade
    {
        public static Func<JsDictionary<string, object>, string> Compile(string source, JadeOptions options = null) { return null; }
        public static string CompileClient(string source, JadeOptions options = null) { return null; }
    }

    [Imported]
    [Serializable]
    public class JadeOptions
    {
        // ...
    }
}
