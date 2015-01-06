using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Html;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("List")]
    public class ListJs
    {
        public ListJs(TypeOption<string, Element> idOrElement, ListJsOptions options) { }
        public ListJs(TypeOption<string, Element> idOrElement, ListJsOptions options, object[] values) { }
    }

    [Imported]
    [Serializable]
    public class ListJsOptions
    {
        public string[] ValueNames;
        public string Item;
        public string ListClass;
        public string SearchClass;
        public string SortClass;
        public bool? IndexAsync;
        public int? Page;
        public int? I;
        public object[] Plugins; // TODO
    }
}
