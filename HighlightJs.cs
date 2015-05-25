using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Html;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("hljs")]
    public class HighlightJs
    {
        public extern static void InitHighlighting();

        public extern static void InitHighlightingOnLoad();

        public extern static void HighlightBlock(Element element);

        public extern static IHighlightJsResult Highlight(string language, string source);
    }

    [Imported]
    [Serializable]
    public interface IHighlightJsResult
    {
        int Relevance { get; }
        
        [ScriptName("value")]
        string Html { get; }
    }
}
