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
        public extern static AceEditor Edit(Element element);
        public extern static AceEditSession CreateEditSession(TypeOption<AceDocument, string> text, TypeOption<AceTextMode, string> mode);
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

        // ace.require("ace/ext/language_tools");
        public bool? EnableBasicAutocompletion;
        public bool? EnableLiveAutocompletion;
        public bool? EnableSnippets;
    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("EditSession")]
    public class AceEditSession
    {
        // no undo manager set!
        public extern AceEditSession(TypeOption<AceDocument, string> text, TypeOption<AceTextMode, string> mode);

        public extern AceDocument GetDocument();
        public extern string GetValue();
        public extern void SetValue(string text);
        public extern void SetMode(string name);
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
