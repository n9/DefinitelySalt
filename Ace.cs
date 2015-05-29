using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Html;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("ace")]
    public static partial class Ace
    {
        public static AceEditor Edit(Element element) { return null; }
        public static AceEditSession CreateEditSession(TypeOption<AceDocument, string> text, TypeOption<AceTextMode, string> mode) { return null; }
    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("Editor")]
    public class AceEditor
    {
        public extern AceEditSession GetSession();
        public extern void SetSession(AceEditSession session);
        public extern void SetOptions(AceOptions session);
        public extern void Resize(bool force = false);

    }

    [Imported]
    [Serializable]
    public class AceOptions
    {
        // https://github.com/ajaxorg/ace/wiki/Configuring-Ace
        public TypeOption<int?, double?> MinLines;
        public TypeOption<int?, double?> MaxLines;
        public bool? AutoScrollEditorIntoView;
        public bool? HScrollBarAlwaysVisible;

    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("EditSession")]
    public class AceEditSession
    {
        // no undo manager set!
        public AceEditSession(TypeOption<AceDocument, string> text, TypeOption<AceTextMode, string> mode) { }

        public AceDocument GetDocument() { return null; }
        public string GetValue() { return null; }
        public void SetValue(string text) { }
    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("Document")]
    public class AceDocument
    {
        public string GetValue() { return null; }
        public void SetValue(string text) { }
    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("TextMode")]
    public class AceTextMode
    {
        
    }   
}
