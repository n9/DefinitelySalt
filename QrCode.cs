using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Html;

namespace DefinitelySalt
{
    [Imported]
    [Serializable]
    public class QrCodeOptions
    {
        public string Text;
        public int? Width;
        public int? Height;
        public string DarkColor;
        public string LightColor;
        public QrCode.CorrectLevel CorrectLevel;
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("QRCode")]
    public class QrCode
    {
        public QrCode(TypeOption<Element, string> elementOrId, TypeOption<QrCodeOptions, string> optionsOrText) { }

        [Imported]
        public enum CorrectLevel
        {
            M,
            L, 
            Q, 
            H
        }
    }
}
