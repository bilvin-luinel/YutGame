using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class LoginHandler : MonoBehaviour
{

    private WebSocket ws;
    void Start()
    {
        ws = new WebSocket("ws://127.0.0.1:8484");
        ws.OnMessage += ws_OnMessage;
        ws.OnOpen += ws_OnOpen;
        ws.OnClose += ws_OnClose;
        ws.Connect();
        ws.Send("1 client has accessed the server");
    }

    void ws_OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);
    }
    void ws_OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("Connecting to server...");
    }
    void ws_OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Lost connection with server");
    }
    public void clickLoginBT()
    {
        
    }

}
