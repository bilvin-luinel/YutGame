using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WebSocketSharp;

public class MainHandler : MonoBehaviour
{
    private WebSocket ws;
    void Start()
    {
        ws = new WebSocket("ws://127.0.0.1:8888");
        ws.OnMessage += ws_OnMessage;
        ws.OnOpen += ws_OnOpen;
        ws.OnClose += ws_OnClose;
        ws.Connect();
    }
    void ws_OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);
    }
        void ws_OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("Connecting to main server...");
    }
    void ws_OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Lost connection with main server");
        // Start();
    }
}
