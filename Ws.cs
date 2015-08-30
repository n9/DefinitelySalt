using NodeJS.EventsModule;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    // https://github.com/websockets/ws/blob/master/doc/ws.md

    [Imported]
    [IgnoreNamespace]
    [ModuleName("ws")]
    [ScriptName("WebSocket")]
    public class WsWebSocket : EventEmitter
    {
        public extern WsWebSocket(string address, TypeOption<string, string[]> protocols = null, WsWebSocketOptions options = null);
    
        [InlineCode("{this}.on('open', {handler})")]
        public extern void OnOpen(Action handler);

        [InlineCode("{this}.on('" + WsWebSocketEvent.Error + "', {handler})")]
        public extern void OnError(Action<string> handler);

        [InlineCode("{this}.on('close', {handler})")]
        public extern void OnClose(Action<string, string> handler);

        [InlineCode("{this}.on('message', {handler})")]
        public extern void OnMessage(Action<object, WsWebSocketFlags> handler);

        public extern void Send(object data, WsWebSocketFlags flags = null, Action<string> callback = null); 

        // ...
    }

    public static class WsWebSocketEvent
    {
        public const string Error = "error";
    }

    [Imported]
    [Serializable]
    public class WsWebSocketOptions
    {
        // https://github.com/websockets/ws/blob/master/doc/ws.md#new-wswebsocketaddress-protocols-options

        // ...
    }

    [Imported]
    [Serializable]
    public class WsWebSocketFlags
    {
        public bool Mask;
        public bool Binary;
        public bool Compress;
    }

    [Imported]
    [IgnoreNamespace]
    [ModuleName("ws")]
    [ScriptName("Server")]
    public class WsWebSocketServer : EventEmitter
    {
        public extern WsWebSocketServer(WsWebSocketServerOptions options = null);
    
        [InlineCode("{this}.on('connection', {handler})")]
        public extern void OnConnection(Action<WsWebSocket> handler);
        
        [InlineCode("{this}.on('error', {handler})")]
        public extern void OnError(Action<string> handler);

        // ...
    }

    [Imported]
    [Serializable]
    public class WsWebSocketServerOptions
    {
        // https://github.com/websockets/ws/blob/master/doc/ws.md#new-wsserveroptions-callback

        public string Host;
        public int Port;
        public NodeJS.HttpModule.Server Server;
        public string Path;

        // ...
    }
}
