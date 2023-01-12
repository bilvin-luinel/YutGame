using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using WebSocketSharp;
using TMPro;

public class LoginHandler : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputPW;
    private WebSocket ws;
    void Start()
    {
        ws = new WebSocket("ws://127.0.0.1:8484");
        ws.OnMessage += ws_OnMessage;
        ws.OnOpen += ws_OnOpen;
        ws.OnClose += ws_OnClose;
        ws.Connect();
    }

    void ws_OnMessage(object sender, MessageEventArgs e)
    {
        if (e.Data == "OK")
        {
            SceneManager.LoadScene("MainScene");
        };
    }
    void ws_OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("Connecting to login server...");
    }
    void ws_OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Lost connection with login server");
        // Start();
    }
    public void clickLoginBT()
    {
        UserInfo userInfo = new UserInfo();
        userInfo.userID = inputID.text;
        userInfo.userPW = inputPW.text;

        ws.Send(JsonUtility.ToJson(userInfo));
        Debug.Log(JsonUtility.ToJson(userInfo));

    }

}

public class UserInfo {
    public string userID;
    public string userPW;
}