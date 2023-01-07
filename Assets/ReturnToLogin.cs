using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToLogin : MonoBehaviour
{
    public void returnToLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
