// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// using WebSocketSharp;
// using TMPro;

// public class RegistHandler : MonoBehaviour
// {
//     public TMP_InputField inputID_signup;
//     public TMP_InputField inputPW_signup;
//     private WebSocket ws;
//     void Start()
//     {
//         ws = new WebSocket("ws://127.0.0.1:8585");
//         ws.OnMessage += ws_OnMessage;
//         ws.OnOpen += ws_OnOpen;
//         ws.OnClose += ws_OnClose;
//         ws.Connect();
//         ws.Send("1 client has accessed the regist server");
//     }

//     void ws_OnMessage(object sender, MessageEventArgs e)
//     {
//         Debug.Log(e.Data);
//     }
//     void ws_OnOpen(object sender, System.EventArgs e)
//     {
//         Debug.Log("Connecting to regist server...");
//     }
//     void ws_OnClose(object sender, CloseEventArgs e)
//     {
//         Debug.Log("Lost connection with regist server");
//     }
//     public void clickSignupBT()
//     {
//         SignupUserInfo signupUserInfo = new SignupUserInfo();
//         signupUserInfo.signupUserID = inputID_signup.text;
//         signupUserInfo.signupUserPW = inputPW_signup.text;

//         string signupUserInfo_json = JsonUtility.ToJson(signupUserInfo);

//         ws.Send(signupUserInfo_json);
//         Debug.Log(signupUserInfo_json);
//     }

// }

// public class SignupUserInfo {
//     public string signupUserID;
//     public string signupUserPW;
// }