
using UnityEngine;
using static Pullable_script;

[System.Serializable]
public class PullableData
{
    public Obj_Type type;
    public float[] position = new float[3];

    public PullableData(Pullable_script Pullable_obj) {
        type = Pullable_obj.obj_Type;

        Vector3 p_obj_pos = Pullable_obj.transform.position;

        position = new float[] { p_obj_pos.x,p_obj_pos.y, p_obj_pos.z };


    }

}