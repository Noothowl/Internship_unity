using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelV1 : MonoBehaviour, ISaveableV1
{
    [SerializeField] private int lvl = 1;
    [SerializeField] private int xp = 100;

    public object SaveState()
    {
        return new SaveData
        {
            lvl = lvl, xp = xp
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        lvl= saveData.lvl;
        xp= saveData.xp;
    }


    [SerializeField]
    private struct SaveData
    {
        public int lvl;
        public int xp;
    }
}
