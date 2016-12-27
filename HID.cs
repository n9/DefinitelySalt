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

    [Imported]
    [IgnoreNamespace]
    [ScriptName(null)]
    [ModuleName("node-hid")]
    public static class HidModule
    {
        [ScriptName("devices")]
        public extern static List<HidDevice> ListDevices();
    }

    [Imported]
    [Serializable]
    public class HidDevice
    {
        public int VendorId;
        public int ProductId;
        public string Path;
        public string SerialNumber;
        public string Manufacturer;
        public string Product;
        public int Release;
        public int Interface;
    }
}
