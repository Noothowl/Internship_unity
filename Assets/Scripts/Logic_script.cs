using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic_script : MonoBehaviour
{
    public void ExitSession()
    {   
        UnityEditor.EditorApplication.isPlaying= false;
        Application.Quit();
    }

    public void StartSession()
    {
        SceneManager.LoadScene("Crane_sample");

    }

}
