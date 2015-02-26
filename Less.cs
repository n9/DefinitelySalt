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
    public enum LessLogLevel
    {
        None = 0,
        Error = 1,
        Warn = 2,
        Info = 3,
        Debug = 4
    }

    [Imported]
    public interface ILessLogger
    {
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
    }

    [Imported]
    [Serializable]
    public class LessOptions
    {
        [ScriptName("filename")]
        public string FileName;
        public bool RelativeUrls;
        public string RootPath;


        public bool? DumpFileNumbers;
        public bool? ProcessImports;
        public bool? StrictImports;
        public bool? Compress;
        public bool? IeCompat;

        public bool? JavascriptEnabled;
        
        // ...

        public LessFileInfo RootFileInfo;
        public LessSourceMapOptions SourceMap;
        public List<ILessPlugin> Plugins;

        public JsDictionary<string, string> GlobalVars;
        public JsDictionary<string, string> ModifyVars;
        public string Banner;
    }

    [Imported]
    [Serializable]
    public class LessSourceMapOptions
    {
        public bool SourceMapFileInline;
        // ...
    }


    [Imported]
    public interface ILessContext
    {
        ILessPluginManager PluginManager { get; }

        //    public int? NumPrecision;
        //    public int? TabLevel;
    }

    [Imported]
    public interface ILessEnvironment
    {
        ILessFileManager GetFileManager(string fileName, string currentDirectory, LessOptions options, ILessEnvironment environment, bool isSync);
        void AddFileManager(ILessFileManager fileManager);
        void ClearFileManagers();
    }

    [Imported]
    [Serializable]
    public class LessLoadedFile
    {
        [ScriptName("filename")]
        public string FileName;

        public string Contents;

        public LessWebInfo WebInfo;
    }

    [Imported]
    [Serializable]
    public class LessWebInfo
    {
        public object Remaining;
        public DateTime LastModified;
        public bool Local;
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("less")]
    public static class Less
    {
        public static extern void Render(string input, LessOptions options, LessRenderCallback callback);
    }

    public delegate void LessRenderCallback(LessError error, LessRenderOutput output);

    public delegate void LessLoadFileCallback(LessError error, LessLoadedFile loadedFile);

    [Imported]
    [Serializable]
    public class LessRenderOutput
    {
        public string Css;
        public string Map;
        public string[] Imports; 
    }

    [Imported]
    [ScriptNamespace("less")]
    [ScriptName("LessError")]
    public class LessError : Error
    {
        public LessError(TypeOption<LessError, Error> error, ILessImportManager importManager = null, string currentFileName = null) { }

        public string Type;
        [ScriptName("filename")]
        public string FileName;
        public int? Index;
        public int? Line;
        public int CallLine;
        public string CallExtract;
        public int Column;
        public string[] Extract;
    }

    [Imported]
    public interface ILess
    {

    }

    [Imported]
    public interface ILessPluginManager
    {
        void AddFileManager(ILessFileManager manager);
    }

    [Imported]
    public interface ILessPlugin
    {
        void Install(ILess less, ILessPluginManager manager);
    }

    [Imported]
    public interface ILessImportManager
    {
        JsDictionary<string, string> Contents { get; }
    }

    [Imported]
    public interface ILessFileManager
    {
        void LoadFile(string path, string currentDirectory, ILessContext context, ILessEnvironment environment, LessLoadFileCallback callback);
        bool AlwaysMakePathsAbsolute();
        string Join(string basePath, string laterPath);
        bool Supports(string fileName, string currentDirectory, LessOptions /*ILessContext?*/ options, ILessEnvironment environment);
        void ClearFileCache();
    }

    [Imported]
    [ScriptNamespace("less")]
    [ScriptName("AbstractFileManager")]
    public abstract class LessAbstractFileManager : ILessFileManager
    {
        extern public virtual string GetPath(string fileName);
        extern public virtual string TryAppendLessExtension(string path);
        extern public virtual bool SupportSync();
        extern public virtual bool AlwaysMakePathsAbsolute();
        extern public virtual bool IsPathAbsolute(string fileName);
        extern public virtual string Join(string basePath, string laterPath);
        extern public virtual string PathDiff(string url, string baseUrl);

        extern protected virtual object /*TODO*/ ExtractUrlParts(string url, string baseUrl);

        public abstract void LoadFile(string path, string currentDirectory, ILessContext context, ILessEnvironment environment, LessLoadFileCallback callback);

        public abstract bool Supports(string fileName, string currentDirectory, LessOptions options, ILessEnvironment environment);

        public abstract void ClearFileCache();
    }
}
