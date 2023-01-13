using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic_script : MonoBehaviour
{
    public int alert;
    protected SaveSystem_script saveSystem;

    private void Start()
    {
        saveSystem = gameObject.GetComponent<SaveSystem_script>();
    }
    public void ExitSession()
    {
        saveSystem.SavePullables();
        Debug.Log("Saved");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void StartSession()
    {

        SceneManager.LoadScene("Crane_sample");

    }

    public void LoadState()
    {
        GameObject[] Deleteables = GameObject.FindGameObjectsWithTag("Pullable");
        foreach (GameObject Pullable_delete in Deleteables)
            Destroy(Pullable_delete);
        Debug.Log("Borrados los obj");
        saveSystem.LoadPullables();
        Debug.Log("Cargados");


    }

}
