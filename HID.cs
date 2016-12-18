using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;
using System.Runtime.CompilerServices;
using System.Collections.TypedArrays;
using NodeJS.EventsModule;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("HID")]
    [ModuleName("node-hid")]
    public class Hid : EventEmitter
    {
        public extern Hid(string path);
        public extern Hid(int vendorId, int productId);
        public extern void Close();
    }
}
