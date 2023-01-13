using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public class SaveLoadV1 : MonoBehaviour
{
    private string SavePath => $"{Application.persistentDataPath}/save.txt";

    private void SaveState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<SaveEntityV1>())
        {
            state[saveable.Id] = saveable.SaveState();
        }
    }

    private void LoadState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<SaveEntityV1>())
        {
            if (state.TryGetValue(saveable.Id, out object value))
            {
                saveable.LoadState(value);
            }
        }

    }

    [ContextMenu("Save")]
    private void Save()
    {
        var state = LoadFile();
        SaveState(state);
        SaveFile(state);
    }



    [ContextMenu("Load")]
    private void Load()
    {
        var state = LoadFile();
        LoadState(state);
    }


    private void SaveFile(object state)
    {
        using (var stream = System.IO.File.Open(SavePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    private Dictionary<string, object> LoadFile()
    {
        if (!System.IO.File.Exists(SavePath)) 
        {
            return new Dictionary<string, object>();
        }

        using (FileStream stream = System.IO.File.Open(SavePath, FileMode.Open))
        {   
            var formatter = new BinaryFormatter();
            return (Dictionary<string,object>)formatter.Deserialize(stream);
        }
    
    }
}
