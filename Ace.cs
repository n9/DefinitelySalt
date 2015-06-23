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

        [IntrinsicProperty]
        public extern static IAceConfig Config { get; }
    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("EventEmitter")]
    public class AceEventEmitter
    {
        public extern void Once(string eventName, Action handler);
        public extern void On(string eventName, Action handler);
        public extern void Off(string eventName, Action handler);
    }


    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("Editor")]
    public class AceEditor : AceEventEmitter
    {
        public extern AceEditSession GetSession();
        public extern void SetSession(AceEditSession session);
        public extern void SetOptions(AceOptions session);
        public extern void Resize(bool force = false);

        public event Action Changed
        {
            [InlineCode("{this}.on('change', {value})")]
            add { }
            [InlineCode("{this}.off('change', {value})")]
            remove { }
        }

        public event Action Input
        {
            [InlineCode("{this}.on('input', {value})")]
            add { }
            [InlineCode("{this}.off('input', {value})")]
            remove { }
        }
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
        public bool? UseWorker;
        public bool? ReadOnly;

        // ace.require("ace/ext/language_tools");
        public bool? EnableBasicAutocompletion;
        public bool? EnableLiveAutocompletion;
        public bool? EnableSnippets;
    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("EditSession")]
    public class AceEditSession : AceEventEmitter
    {
        // no undo manager set!
        public extern AceEditSession(TypeOption<AceDocument, string> text, TypeOption<AceTextMode, string> mode);

        public extern AceDocument GetDocument();
        public extern string GetValue();
        public extern void SetValue(string text);
        public extern void SetMode(string name);

        public extern void SetAnnotations(AceAnnotation[] annotations);

        public event Action Changed
        {
            [InlineCode("{this}.on('change', {value})")]
            add { }
            [InlineCode("{this}.off('change', {value})")]
            remove { }
        }
    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("Document")]
    public class AceDocument : AceEventEmitter
    {
        public extern AceDocument(string text);
        public extern AceDocument(string[] lines);

        public extern string GetValue();
        public extern void SetValue(string text);

        public event Action Changed
        {
            [InlineCode("{this}.on('change', {value})")]
            add { }
            [InlineCode("{this}.off('change', {value})")]
            remove { }
        }
    }

    [Imported]
    [ScriptNamespace("ace")]
    [ScriptName("TextMode")]
    public class AceTextMode
    {
        
    }   

    [Imported]
    [NamedValues]
    public enum AceAnnotationType
    {
        Error, Warning, Info
    }

    [Imported]
    [Serializable]
    public class AceAnnotation
    {
        public int Row;
        public int Column;
        public string Text;
        public AceAnnotationType Type;
    }

    [Imported]
    public interface IAceConfig
    {
        void LoadModule(string moduleName, Action<object> onLoad);
    }
}
