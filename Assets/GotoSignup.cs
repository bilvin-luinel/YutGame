using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoSignup : MonoBehaviour
{

    public void GoToSignup()
    {
        SceneManager.LoadScene("SignupScene");
    }
}
