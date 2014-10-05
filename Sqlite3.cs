using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodeJS;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [GlobalMethods]
    [ModuleName("sqlite3")]    
    public static class SQLite3File
    {
        public const string Memory = ":memory:";
    }

    [Flags]
    [Imported]
    [IgnoreNamespace]
    [ScriptName("sqlite3")]
    public enum SQLite3Mode
    {
        [ScriptName("OPEN_READONLY")]
        ReadOnly,

        [ScriptName("OPEN_READWRITE")]
        ReadWrite,

        [ScriptName("OPEN_CREATE")]
        Create
    }

    public class SQLite3Error
    {
        public string Code;
        [ScriptName("errno")]
        public int Number;

        public string Message;
        public string Stack;
    }

    public delegate void SQLite3Callback(SQLite3Error error);
    public delegate void SQLite3GetCallback(SQLite3Error error, JsDictionary<string, object> row);
    public delegate void SQLite3AllCallback(SQLite3Error error, JsDictionary<string, object>[] rows);
    public delegate void SQLite3EachComplete(SQLite3Error error, int count);

    [Imported]
    [IgnoreNamespace]
    [ModuleName("sqlite3")]
    [ScriptName("Database")]
    public partial class SQLite3Database
    {
        public SQLite3Database(string fileName, SQLite3Mode? mode = null, SQLite3Callback callback = null) { }

        public void Close() { }

        public SQLite3Database Serialize() { return null; }
        public SQLite3Database Serialize(Action action) { return null; }

        public SQLite3Database Parallelize() { return null; }
        public SQLite3Database Parallelize(Action action) { return null; }

        public SQLite3Database Exec(string commands) { return null; }
        public SQLite3Database Exec(string commands, SQLite3Callback callback) { return null; }

        public SQLite3Statement Prepare(string command) { return null; }
        public SQLite3Statement Prepare(string command, SQLite3Callback callback) { return null; }
    }

    [Imported]
    [IgnoreNamespace]
    [ModuleName("sqlite3")]
    [ScriptName("Statement")]
    public abstract partial class SQLite3Statement
    {
        [IntrinsicProperty]
        [ScriptName("lastID")]
        public int? LastId { get { return null; } }

        [IntrinsicProperty]
        public int? Changes { get { return null; } }

        public SQLite3Statement Bind(params object[] args) { return null; }
        public SQLite3Statement Bind(JsDictionary<string, object> args) { return null; }

        public SQLite3Statement Reset(Action callback) { return null; }

        public SQLite3Statement Run() { return null; }
        public SQLite3Statement Run(SQLite3Callback callback) { return null; }

        public SQLite3Statement Get(SQLite3GetCallback callback) { return null; }

        public SQLite3Statement All(SQLite3AllCallback callback) { return null; }

        public SQLite3Statement Each(SQLite3GetCallback callback) { return null; }
        public SQLite3Statement Each(SQLite3GetCallback callback, SQLite3EachComplete complete) { return null; }

#pragma warning disable 0465
        public SQLite3Database Finalize() { return null; }
#pragma warning restore 0465
    }

    // extra
    public partial class SQLite3Database
    {
        public SQLite3Database Run(string command, object arg1, object arg2) { return null; }
        public SQLite3Database Run(string command, object arg1, object arg2, SQLite3Callback callback) { return null; }
        public SQLite3Database Run(string command, object arg1, object arg2, object arg3, SQLite3Callback callback) { return null; }
        public SQLite3Database Get(string command, SQLite3GetCallback callback) { return null; }
        public SQLite3Database Get(string command, object arg1, SQLite3GetCallback callback) { return null; }
        public SQLite3Database All(string command, SQLite3AllCallback callback) { return null; }
        public SQLite3Database All(string command, object arg1, object arg2, SQLite3AllCallback callback) { return null; }
    }

    public abstract partial class SQLite3Statement
    {
        public SQLite3Statement Run(object arg1, object arg2) { return null; }
        public SQLite3Statement Run(object arg1, object arg2, SQLite3Callback callback) { return null; }
    }

    public static class SQLite3DatabaseEx
    {
        public static SQLite3Database InTransaction(this SQLite3Database db, Action body)
        {
            db.Exec("begin");
            try 
            {
                body();
                db.Exec("commit");
            }
            catch
            {
                db.Exec("rollback");
                throw;
            }
            return db;
        }
    }
}