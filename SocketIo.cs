using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using NodeJS.HttpModule;
using System.Threading.Tasks;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ModuleName("socket.io")]
    [ScriptName("")]
    public static class SocketIo
    {
        public static ISocketIoManager Listen(Server server) { return null; }
    }

    [Imported]
    public interface ISocketIoManager
    {
        ISocketIoNamespace Sockets { [InlineCode("{this}.sockets", GeneratedMethodName="sockets")] get; }
        ISocketIoNamespace Of(string socketNamespace);
        JsDictionary<string, ISocketIoNamespace> Namespaces { [InlineCode("{this}.namespaces", GeneratedMethodName = "namespaces")] get; }
    }

    [Imported]
    public interface ISocketIoEmitter
    {
        void Emit(string eventName, object data);
    }

    [Imported]
    public interface ISocketIoEmitter<TThis> : ISocketIoEmitter
    {
        TThis In(string room);
        TThis To(string room);
    }

    [Imported]
    public interface ISocketIoNamespace : ISocketIoEmitter<ISocketIoNamespace>
    {
        [InlineCode("{this}.on('connection', {handler})", GeneratedMethodName = "on")]
        void OnConnection(Action<ISocketIoServerSocket> handler);

        ISocketIoServerSocket Socket(string socketId);

        ISocketIoServerSocket[] Clients(string room = null);
    }

    [Imported]
    public interface ISocketIoSocket : ISocketIoEmitter
    {
        void On(string eventName, Delegate handler);
        void On(string eventName, Action<object> handler);
        
        void Once(string eventName, Delegate handler);
        void Once(string eventName, Action<object> handler);

        void RemoveAllListeners(string eventName);

        [InlineCode("{this}.on('disconnect', {handler})", GeneratedMethodName = "on")]
        void OnDisconnect(Action handler);

        void Disconnect();
    }

    [Imported]
    public interface ISocketIoSocket<TThis> : ISocketIoSocket, ISocketIoEmitter<TThis>
    {
    }

    [Imported]
    public interface ISocketIoServerSocket : ISocketIoSocket<ISocketIoServerSocket>
    {
        ISocketIoServerSocket Join(string room);
        ISocketIoServerSocket Leave(string room);
        ISocketIoServerSocket Broadcast { [InlineCode("{this}.broadcast", GeneratedMethodName = "broadcast")] get; }
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("io")]
    public static class SocketIoClient
    {
        public static ISocketIoClientSocket Connect(string url) { return null; }
    }

    [Imported]
    public interface ISocketIoClientSocket : ISocketIoSocket<ISocketIoClientSocket>
    {
        [InlineCode("{this}.on('connect', {handler})", GeneratedMethodName="on")]
        void OnConnect(Action handler);

        [InlineCode("{this}.on('connecting', {handler})", GeneratedMethodName = "on")]
        void OnConnecting(Action handler);

        [InlineCode("{this}.on('connect_failed', {handler})", GeneratedMethodName = "on")]
        void OnConnectFailed(Action handler);

        [InlineCode("{this}.on('error', {handler})", GeneratedMethodName = "on")]
        void OnError(Action handler);

        [InlineCode("{this}.on('reconnect', {handler})", GeneratedMethodName = "on")]
        void OnReconnect(Action handler);

        [InlineCode("{this}.on('reconnecting', {handler})", GeneratedMethodName = "on")]
        void OnReconnecting(Action handler);

        [InlineCode("{this}.on('reconnect_failed', {handler})", GeneratedMethodName = "on")]
        void OnReconnectFailed(Action handler);
    }
}
