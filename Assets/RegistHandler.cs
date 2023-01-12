using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using WebSocketSharp;
using TMPro;

public class RegistHandler : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputPW;
    public TMP_InputField inputName;
    public TMP_InputField inputNickName;
    private WebSocket ws;
    void Start()
    {
        ws = new WebSocket("ws://127.0.0.1:8585");
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
        Debug.Log("Connecting to regist server...");
    }
    void ws_OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Lost connection with regist server");
        Start();
    }
    public void clickSignupBT()
    {
        SignupUserInfo signupUserInfo = new SignupUserInfo();
        signupUserInfo.userID = inputID.text;
        signupUserInfo.userPW = inputPW.text;
        signupUserInfo.userName = inputName.text;
        signupUserInfo.userNickName = inputNickName.text;

        ws.Send(JsonUtility.ToJson(signupUserInfo));
        Debug.Log(JsonUtility.ToJson(signupUserInfo));
    }

}

public class SignupUserInfo
{
    public string userID;
    public string userPW;
    public string userName;
    public string userNickName;
}