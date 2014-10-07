using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Imported]
    public class jQueryEventName
    {
        [ScriptSkip]
        public static implicit operator jQueryEventName(string name) { return null; }

        [ScriptSkip]
        public static implicit operator jQueryEventName(ElementEvents name) { return null; }
    }

    [Imported]
    public class jQueryEventName<TDelegate>
    {
        [ScriptSkip]
        public static implicit operator jQueryEventName<TDelegate>(string name) { return null; }
    }
}
