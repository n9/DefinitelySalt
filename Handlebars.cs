using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    [Imported]
    [Serializable]
    public class HandlebarsOptions
    {
        public JsDictionary<string, object> Data;
        public JsDictionary<string, Delegate> Helpers;
        public JsDictionary<string, Delegate> Partials;
    }

    [Imported]
    [Serializable]
    public class HandlebarsPrecompiledTemplate
    {

    }

    public delegate string HandlerbarsTemplate(JsDictionary<string, object> context, HandlebarsOptions options = null);

    [Imported]
    [IgnoreNamespace]
    public static class Handlebars
    {
        public static HandlerbarsTemplate Compile(string source, HandlebarsOptions options = null) { return null; }
        public static string Precompile(string source, HandlebarsOptions options = null) { return null; }
        public static HandlerbarsTemplate Template(HandlebarsPrecompiledTemplate precompiled) { return null; }
    }
}
