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

    public delegate string HandlerbarsTemplate(JsDictionary<string, object> context, HandlebarsOptions options = null);

    [Imported]
    [IgnoreNamespace]
    public static class Handlebars
    {
        public static HandlerbarsTemplate Compile(string source) { return null; }
    }
}
