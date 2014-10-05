using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodeJS;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    [Imported]
    [Serializable]
    public class SequelizeOptions
    {
        public string Host;
        public int Port;
        public string Protocol;
        public object Logging;
        public int MaxConcurrentQueries;
        public string Dialect;
        public string Storage;
        public bool OmitNull;
        public SequelizeDefineOptions Define;
        public SequelizeSyncOptions Sync;
        public bool SyncOnAssociation;
        public SequelizePoolOptions Pool;
        
        public bool ForeignKeys; // SQLite only?
    }

    [Imported]
    [Serializable]
    public class SequelizePoolOptions
    {
        // TODO
    }

    public static class SequelizeProtocol
    {
        public const string Tcp = "tcp";
    }

    public static class SequelizeDialect
    {
        public const string MySQL = "mysql";
        public const string SQLite = "sqlite";
        public const string Postgres = "postgres";
    }

    public static class SequelizeQueryType
    {
        public const string Select = "SELECT";
    }

    [Imported]
    [Serializable]
    public class SequelizeQueryOptions
    {
        public object Logging;
        public bool Plain;
        public bool Raw;
        public object Type;
    }
    
    [Imported]
    public interface ISequelize
    {
        ISequelizePromise<ISequelizeError> Query(string sql);
        ISequelizePromise<ISequelizeError, T> Query<T>(string sql);
        ISequelizePromise<ISequelizeError, T> Query<T>(string sql, object callee, SequelizeQueryOptions options, object[] replacements);
        SequelizeModel<T> Define<T>(string name, JsDictionary<string, SequelizeColumn> fields, SequelizeDefineOptions options = null)
            where T : SequelizeEntity<T>;
        SequelizeModel Define(string name, JsDictionary<string, SequelizeColumn> columns, SequelizeDefineOptions options = null);
    }

    public static partial class SequelizeBuilder
    {
        public static ISequelize ConnectSqlite(string storage, SequelizeOptions options = null)
        {
            options = options ?? new SequelizeOptions();
            options.Dialect = SequelizeDialect.SQLite;
            options.Storage = storage;
            return Connect(null, null, null, options);
        }

        [InlineCode("new (require('sequelize'))({database}, {username}, {password}, {options})")]
        public static ISequelize Connect(string database, string username, string password = null, SequelizeOptions options = null) { return null; }
    }

    [Imported]
    [IgnoreNamespace]
    [ModuleName("sequelize")]
    [GlobalMethods]
    public static partial class Sequelize
    {
        [ScriptName("STRING")] 
        public static SequelizeDataType String;
        [ScriptName("TEXT")] 
        public static SequelizeDataType Text;
        [ScriptName("INTEGER")]
        public static SequelizeDataType Integer;
        [ScriptName("BIGINT")]
        public static SequelizeDataType BigInt;
        [ScriptName("DATE")] 
        public static SequelizeDataType Date;
        [ScriptName("BOOLEAN")]
        public static SequelizeDataType Boolean;
        [ScriptName("FLOAT")]
        public static SequelizeDataType Float;
        [ScriptName("ENUM")]
        [ExpandParams]
        public static SequelizeDataType Enum(params string[] values) { return null; }
        [ScriptName("DECIMAL")]
        public static SequelizeDataType Decimal(int precision, int? scale = null) { return null; }
        [ScriptName("ARRAY")]
        public static SequelizeDataType Array(SequelizeDataType type) { return null; }
    }

    public static partial class Sequelize
    {
        [ScriptName("NOW")]
        public static object Now;
    }

    [SimpleCustomPropertyModel(
        Getter = "{{this}}.{0}", 
        Setter = "{{value}} === null ? null : ({{this}}.{0}Id = {{value}}.id)")]
    [Imported, IgnoreNamespace, ScriptName("Object")]
    public abstract partial class SequelizeEntity<T>
        where T : SequelizeEntity<T>
    {
        [ScriptSkip]
        public SequelizeEntity() { } // prevent `Object.call(this);`

        // public int Id;

        [IntrinsicProperty]
        public DateTime? CreatedAt { get { return null; } }

        [IntrinsicProperty]
        public DateTime? UpdatedAt { get { return null; } }
    }

    public static class SequelizeEntityEx
    {
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError, T> Save<T>(this T entity)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError, T> Save<T>(this T entity, string[] storeColumns)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError, T> UpdateAttributes<T>(this T entity, T attributes)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError, T> UpdateAttributes<T>(this T entity, JsDictionary<string, object> attributes)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError> Destroy<T>(this T entity)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError> Reload<T>(this T entity)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError> Increment<T>(this T entity, string column, int number)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError> Increment<T>(this T entity, string[] columns, int number)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError> Increment<T>(this T entity, JsDictionary<string, int> columnNumbers)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError> Decrement<T>(this T entity, string column, int number)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError> Decrement<T>(this T entity, string[] columns, int number)
            where T : SequelizeEntity<T> { return null; }
        [InstanceMethodOnFirstArgument]
        public static ISequelizePromise<ISequelizeError> Decrement<T>(this T entity, JsDictionary<string, int> columnNumbers)
            where T : SequelizeEntity<T> { return null; }

        [InlineCode("{target}.values")]
        public static T GetValues<T>(this T target)
            where T : SequelizeEntity<T> { return default(T); }

        [InlineCode("{target}.values")]
        public static JsDictionary<string, object> GetValuesMap<T>(this T target)
            where T : SequelizeEntity<T> { return null; }
        
        [InlineCode("{target}.has{entityName}({entity})")]
        public static ISequelizePromise<ISequelizeError, bool> Has<T, E>(T target, string entityName, E entity)
            where T : SequelizeEntity<T>
            where E : SequelizeEntity<E> { return null; }

        [InlineCode("{target}.has{entitiesName}({entities})")]
        public static ISequelizePromise<ISequelizeError, bool> Has<T, E>(T target, string entitiesName, E[] entities)
            where T : SequelizeEntity<T>
            where E : SequelizeEntity<E> { return null; }

        [InlineCode("{target}.add{entityName}({entity})")]
        public static ISequelizePromise<ISequelizeError, E> Add<T, E>(T target, string entityName, E entity)
            where T : SequelizeEntity<T>
            where E : SequelizeEntity<E> { return null; }

        [InlineCode("{target}.set{entityName}({entity})")]
        public static ISequelizePromise<ISequelizeError, E[]> Set<T, E>(T target, string entityName, E entity)
            where T : SequelizeEntity<T>
            where E : SequelizeEntity<E> { return null; }

        [InlineCode("{target}.set{entitiesName}({entities})")]
        public static ISequelizePromise<ISequelizeError, E[]> Set<T, E>(T target, string entitiesName, E[] entities)
            where T : SequelizeEntity<T>
            where E : SequelizeEntity<E> { return null; }

        [InlineCode("{target}.get{entityName}()")]
        public static ISequelizePromise<ISequelizeError, E> Get<T, E>(T target, string entityName)
            where T : SequelizeEntity<T>
            where E : SequelizeEntity<E> { return null; }

        [InlineCode("{target}.get{entitiesName}({criteria})")]
        public static ISequelizePromise<ISequelizeError, E[]> GetAll<T, E>(T target, string entitiesName, SequelizeFindCriteria criteria = null)
            where T : SequelizeEntity<T>
            where E : SequelizeEntity<E> { return null; }
    }

    [Imported]
    public abstract partial class SequelizeModel
    {
        public ISequelizePromise<ISequelizeError> Sync(SequelizeSyncOptions options = null) { return null; }
        public ISequelizePromise<ISequelizeError> Drop() { return null; }
        public ISequelizePromise<ISequelizeError, int> Count(SequelizeFindCriteria criteria = null) { return null; }
        public ISequelizePromise<ISequelizeError, object> Min(string column) { return null; }
        public ISequelizePromise<ISequelizeError, object> Max(string column) { return null; }

        // extra
        [IntrinsicProperty]
        public new string TableName { get { return null; } }
        
        [IntrinsicProperty]
        [ScriptName("attributes")]
        public JsDictionary<string, string> SqlColumns { get { return null; } }
        
        [IntrinsicProperty]
        [ScriptName("rawAttributes")]
        public JsDictionary<string, SequelizeColumn> Columns { get { return null; } }
    }

    [Imported]
    public abstract class SequelizeModel<T> : SequelizeModel
        where T : SequelizeEntity<T>
    {
        public T Build() { return null; }
        public T Build(T entity) { return null; }
        public T Build(JsDictionary<string, object> attributes) { return null; }
        public ISequelizePromise<ISequelizeError, T> Create(T entity) { return null; }
        public ISequelizePromise<ISequelizeError, T> Create(T entity, string[] storeColumns) { return null; }
        public ISequelizePromise<ISequelizeError, T> Create(JsDictionary<string, object> attributes) { return null; }
        public ISequelizePromise<ISequelizeError, T> Create(JsDictionary<string, object> attributes, string[] storeColumns) { return null; }
        public ISequelizePromise<ISequelizeError, T> Find(int id) { return null; }
        public ISequelizePromise<ISequelizeError, T> Find(SequelizeFindCriteria criteria) { return null; }
        public ISequelizePromise<ISequelizeError, T> FindOrCreate(T entity) { return null; }
        public ISequelizePromise<ISequelizeError, T> FindOrCreate(T entity, JsDictionary<string, object> set) { return null; }
        public ISequelizePromise<ISequelizeError, T> FindOrCreate(JsDictionary<string, object> where, JsDictionary<string, object> set) { return null; }
        public ISequelizePromise<ISequelizeError, T[]> FindAll(SequelizeFindCriteria criteria) { return null; }
        public ISequelizePromise<ISequelizeError, T[]> FindAll() { return null; }
        public ISequelizePromise<ISequelizeError, T[]> All() { return null; }
    }

    public static class SequelizeModelEx
    {
        [InstanceMethodOnFirstArgument]
        public static M BelongsTo<M>(this M model, SequelizeModel other, SequelizeBelongsToOptions options = null)
            where M : SequelizeModel { return null; }
        [InstanceMethodOnFirstArgument]
        public static M HasOne<M>(this M model, SequelizeModel other, SequelizeHasOneOptions options = null)
            where M : SequelizeModel { return null; }
        [InstanceMethodOnFirstArgument]
        public static M HasMany<M>(this M model, SequelizeModel other, SequelizeHasManyOptions options = null)
            where M : SequelizeModel { return null; }
    }

    [Imported]
    [Serializable]
    public class SequelizeAssociationOptions
    {
        public string As;
        public string ForeignKey;
    }

    [Imported]
    [Serializable]
    public class SequelizeBelongsToOptions : SequelizeAssociationOptions
    {
    }

    [Imported]
    [Serializable]
    public class SequelizeHasOneOptions : SequelizeAssociationOptions
    {
    }


    [Imported]
    [Serializable]
    public class SequelizeHasManyOptions : SequelizeAssociationOptions
    {
        public bool UseJunctionTable;
        public string JoinTableName;
    }

    [Imported]
    [Serializable]
    public class SequelizeIncludeModel
    {
        public SequelizeModel Model;
        public string As;
    }

    [Imported]
    [Serializable]
    public class SequelizeFindCriteria
    {
        public SequelizeIncludeModel[] Include;
        public JsDictionary<string, object> Where;
        [ScriptName("where")]
        public string WhereTerm;
        public object[] Attributes;
        public string Order;
        public int? Limit;
        public int? Offset;
    }

    [Imported]
    [Serializable]
    public class SequelizeSyncOptions
    {
        public bool Force;
    }

    [Imported]
    [Serializable]
    public class SequelizeDefineOptions
    {
        public bool Timestamps;
        public bool Paranoid;
        public bool Underscored;
        public bool FreezeTableName;
        public string TableName;
        public string Charset;
        public string Collate;
        public string Engine;
        public JsDictionary<string, Delegate> InstanceMethods;
        public JsDictionary<string, Delegate> ClassMethods;
    }

    [Imported]
    public abstract class SequelizeDataType { }

    [Imported]
    [Serializable]
    public class SequelizeColumn
    {
        public SequelizeDataType Type;
        public bool AllowNull;
        public object DefaultValue;
        public bool Unique;
        public bool PrimaryKey;
        public bool AutoIncrement;
        public SequelizeValidate Validate;

        [ScriptSkip]
        public static implicit operator SequelizeColumn(SequelizeDataType dataType) { return null; }
    }

    [Imported]
    [Serializable]
    public class SequelizeValidate
    {
        // TODO
    }

    [Imported]
    public interface ISequelizeError
    {
    
    }

    [Imported]
    [ModuleName("sequelize")]
    [ScriptNamespace("Utils")]
    [ScriptName("QueryChainer")]
    public partial class SequelizeQueryChainer
    {
        public SequelizeQueryChainer Add(ISequelizePromise<ISequelizeError> promise) { return null; }
        public ISequelizeQueryChainer<T> Add<T>(ISequelizePromise<ISequelizeError, T> promise) { return null; }
        public SequelizeQueryChainer Add<T>(SequelizeModel<T> model, string functionName, object[] arguments, SequelizeChainerAddOptions<T> options = null)
            where T : SequelizeEntity<T> { return null; }

        public ISequelizeChainedPromise Run() { return null; }
        public ISequelizeChainedPromise RunSerially(SequelizeRunSeriallyOptions options = null) { return null; }
    }

    [Imported]
    public interface ISequelizeQueryChainer<T1>
    {
        ISequelizeQueryChainer<T1, T2> Add<T2>(ISequelizePromise<ISequelizeError, T2> promise);
        ISequelizePromise<ArrayTuple<ISequelizeError>, ArrayTuple<T1>> Run();
        ISequelizePromise<ArrayTuple<ISequelizeError>, ArrayTuple<T1>> RunSerially(SequelizeRunSeriallyOptions options = null);
    }

    [Imported]
    public interface ISequelizeQueryChainer<T1, T2>
    {
        ISequelizeQueryChainer<T1, T2, T3> Add<T3>(ISequelizePromise<ISequelizeError, T3> promise);
        ISequelizePromise<ArrayTuple<ISequelizeError, ISequelizeError>, ArrayTuple<T1, T2>> Run();
        ISequelizePromise<ArrayTuple<ISequelizeError, ISequelizeError>, ArrayTuple<T1, T2>> RunSerially(SequelizeRunSeriallyOptions options = null);
    }

    [Imported]
    public interface ISequelizeQueryChainer<T1, T2, T3>
    {
        // TODO
        ISequelizePromise<ArrayTuple<ISequelizeError, ISequelizeError, ISequelizeError>, ArrayTuple<T1, T2, T3>> RunSerially(SequelizeRunSeriallyOptions options = null);
        ISequelizePromise<ArrayTuple<ISequelizeError, ISequelizeError, ISequelizeError>, ArrayTuple<T1, T2, T3>> Run();
    }

    public delegate void SequelizeChainedErrorCallback(ISequelizeError[] errors);

    [Imported]
    public interface ISequelizePromise<TError>
    {
        ISequelizePromise<TError> Success(Action callback);
        ISequelizePromise<TError> Error(Action<TError> callback);
        ISequelizePromise<TError> Done(Action<TError> callback);
        ISequelizePromise<TError> Sql(Action<string> callback);
    }

    [Imported]
    public interface ISequelizePromise<TError, TResult>
    {
        ISequelizePromise<TError, TResult> Success(Action<TResult> callback);
        ISequelizePromise<TError, TResult> Error(Action<TError> callback);
        ISequelizePromise<TError, TResult> Done(Action<TError, TResult> callback);
        ISequelizePromise<TError, TResult> Sql(Action<string> callback);
    }

    [Imported]
    public interface ISequelizeChainedPromise
    {
        ISequelizeChainedPromise Success(Action callback);
        ISequelizeChainedPromise Success(Action<object[]> callback);
        ISequelizeChainedPromise Error(SequelizeChainedErrorCallback callback);
        ISequelizeChainedPromise Done(SequelizeChainedErrorCallback callback);
        ISequelizeChainedPromise Sql(Action<string> callback);
    }

    [Imported]
    public interface ISequelizeMigration
    {
        // TODO
    }

    [Imported]
    [Serializable]
    public class SequelizeChainerAddOptions<T>
        where T : SequelizeEntity<T>
    {
        public Action<T> Before;
        public Action<ISequelizeMigration> After;
        public Action<ISequelizeMigration, Action> Success; // ??
    }

    [Imported]
    [Serializable]
    public class SequelizeRunSeriallyOptions
    {
        public bool SkipOnError;
    }


}