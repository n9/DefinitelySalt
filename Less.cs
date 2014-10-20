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
        public bool RelativeUrls;
        public string RootPath;
        public string CurrentDirectory;
        public string EntryPath;
        [ScriptName("rootFilename")]
        public string RootFileName;
        public bool Reference;  
    }

    [Imported]
    [Serializable]
    public class LessParseEnvOptions
    {
        public string[] Paths;
        public int? Optimization;
        public string[] Files;
        public JsDictionary<string, string> Contents;
        public JsDictionary<string, int> ContentsIgnoredChars;
        [ScriptName("filename")]
        public string FileName;
    }

    [Imported]
    [ScriptNamespace("less.tree")]
    [ScriptName("parseEnv")]
    public class LessParseEnv : LessParseEnvOptions
    {
        public LessFileInfo CurrentFileInfo;
        public bool? DumpFileNumbers;
        public bool? ProcessImports;
        public bool? StrictImports;
        public bool? Compress;
        public bool? JavascriptEnabled;
        public Func<string, bool> IsPathRelative;
        public bool? IeCompat;
        public bool? Silent;
        public int? NumPrecision;
        public int? TabLevel;

        public LessParseEnv() { }
        public LessParseEnv(LessParseEnvOptions options) { }
    }


    [Imported]
    [IgnoreNamespace]
    [ScriptName("less")]
    public static class Less
    {
        [ScriptName("Parser")]
        public static extern ILessParser Parser(LessParseEnvOptions env = null);

        public static LessParserImporter Importer 
        {
            [InlineCode("{$DefinitelySalt.Less}.Parser.importer")]
            get { return null; }
            [InlineCode("{$DefinitelySalt.Less}.Parser.importer = {value}")]
            set { }
        }

        public static LessParserFileLoader FileLoader
        {
            [InlineCode("{$DefinitelySalt.Less}.Parser.fileLoader")]
            get { return null; }
            [InlineCode("{$DefinitelySalt.Less}.Parser.fileLoader = {value}")]
            set { }
        }
    }

    public delegate void LessParserCallback(LessError error, ILessResult result);

    public delegate void LessFileParsed(LessError error, ILessResult result, string fullPath);

    public delegate void LessFileLoaded(LessError error, string contents, string fullPath, LessFileInfo newFileInfo);

    public delegate void LessParserImporter(string path, LessFileInfo currentFileInfo, LessFileParsed callback, LessParseEnv env);

    public delegate void LessParserFileLoader(string path, LessFileInfo currentFileInfo, LessFileLoaded callback, LessParseEnv env);

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
