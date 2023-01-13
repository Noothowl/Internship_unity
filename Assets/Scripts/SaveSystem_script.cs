using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveSystem_script : MonoBehaviour
{

    [SerializeField] Pullable_script pullable_prefab;
    public static List<Pullable_script> pullables = new List<Pullable_script>();

    const string PULLABLE_SUB = "/pullables";
    const string PULLABLE_SUB_count = "/pullables.count";


    public void SavePullables() 
    {
        BinaryFormatter formatter= new BinaryFormatter();
        string path = Application.persistentDataPath + PULLABLE_SUB+ SceneManager.GetActiveScene().buildIndex;
        string countpath = Application.persistentDataPath + PULLABLE_SUB_count + SceneManager.GetActiveScene().buildIndex;

        FileStream countStream = new FileStream(countpath, FileMode.Create);

        formatter.Serialize(countStream, pullables.Count);
        countStream.Close();

        for (int i = 0; i < pullables.Count; i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            PullableData data = new PullableData(pullables[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }

    }

    public void LoadPullables()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + PULLABLE_SUB + SceneManager.GetActiveScene().buildIndex;
        string countpath = Application.persistentDataPath + PULLABLE_SUB_count + SceneManager.GetActiveScene().buildIndex;
        int pulleableCount = 0;

        if (File.Exists(countpath))
        {
            FileStream countStream = new FileStream(countpath,FileMode.Open);

            pulleableCount = (int)formatter.Deserialize(countStream);
            countStream.Close();
        }
        else
        {
            Debug.LogError("Path not found in "+countpath);
        }

        for (int i = 0; i < pulleableCount; i++)
        {
            if (File.Exists(path + i)) 
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                PullableData data = formatter.Deserialize(stream) as PullableData;
                stream.Close();


                Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
                Pullable_script pullable = Instantiate(pullable_prefab, position, Quaternion.identity);
                pullable.obj_Type = data.type;



            }

            
        }
    }

}
