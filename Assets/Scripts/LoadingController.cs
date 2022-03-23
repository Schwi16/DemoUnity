using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    public void OnChangeScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
