using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Imported]
    [Serializable]
    public class LessFileInfo
    {
        [ScriptName("filename")]
        public string FileName;
    }

    [Imported]
    [Serializable]
    public class LessEnv
    {
        public string[] Paths;
        public int? Optimization;
        public string[] Files;
        public JsDictionary<string, string> Contents;
        public JsDictionary<string, int> ContentsIgnoredChars;


        //public LessFileInfo CurrentFileInfo;
        //public bool? DumpFileNumbers;
        //public bool? ProcessImports;
        //public bool? StrictImports;
        //public bool? Compress;
        //public bool? JavascriptEnabled;
        //public Func<string, bool> IsPathRelative;
        //public bool? IeCompat;
        //public bool? Silent;
        //public int? NumPrecision;
        //public int? TabLevel;
    }


    [Imported]
    [IgnoreNamespace]
    [ScriptName("less")]
    public static class Less
    {
        [ScriptName("Parser")]
        public static extern ILessParser Parser(LessEnv env = null);

        public static LessParserImporter Importer 
        {
            [InlineCode("{$DefinitelySalt.Less}.Parser.importer")]
            get { return null; }
            [InlineCode("{$DefinitelySalt.Less}.Parser.importer = {value}")]
            set { }
        }
    }

    public delegate void LessParserCallback(LessError error, ILessResult result);

    public delegate void LessFileParsed(LessError error, ILessResult result, string fullPath);

    public delegate void LessParserImporter(string path, LessFileInfo currentFileInfo, LessFileParsed callback, LessEnv env);


    [Imported]
    [Serializable]
    public class LessError
    {
        public string Type;
        public string Name;
        public string Message;
        [ScriptName("filename")]
        public string FileName;
        public object Index; // TODO
        public int? Line;
        public int CallLine;
        public string CallExtract;
        public object Stack; // TODO
        public int Column;
        public string[] Extract;
    }

    [Imported]
    public interface ILessResult
    {
        string ToCSS();
    }

    [Imported]
    public interface ILessParser
    {
        void Parse(string source, LessParserCallback callback, JsDictionary<string, object> additionalData);
    }
}
