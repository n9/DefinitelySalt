using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Imported]
    [NamedValues]
    public enum JsBeautifyBraceStyle
    {
        Collapse, // put braces on the same line as control statements
        Expand, // put braces on own line (Allman / ANSI style)
        [ScriptName("end-expand")] 
        EndExpand, // just put end braces on own line
        None // attempt to keep them where they are
    }

    [Imported]
    [Serializable]
    public class JsBeautifyOptions
    {
        [ScriptName("indent_size")]
        public int IndentSize = 4;

        [ScriptName("indent_char")]
        public char IndentChar = ' ';

        [ScriptName("preserve_newlines")]
        public bool PreserveNewLines = true;

        [ScriptName("max_preserve_newlines")]
        public int? MaxPreserveNewLines = null;

        [ScriptName("jslint_happy")]
        public bool JsLintHappy = false;

        [ScriptName("space_after_anon_function")]
        public bool SpaceAfterAnonFunction = false;

        [ScriptName("brace_style")]
        public JsBeautifyBraceStyle BraceStyle = JsBeautifyBraceStyle.Collapse;

        [ScriptName("space_before_conditional")]
        public bool SpaceBeforeConditional = true;

        [ScriptName("unescape_strings")]
        public bool UnescapeStrings = false;

        [ScriptName("wrap_line_length")]
        public int? WrapLineLength = null;

        [ScriptName("end_with_newline")]
        public bool EndWithNewLine = false;
    }

    [GlobalMethods]
    public static class JsBeautify
    {
        [ScriptName("js_beautify")]
        public extern static string Apply(string source, JsBeautifyOptions options = null);
    }
}
