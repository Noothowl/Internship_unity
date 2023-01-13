using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveableV1
{
    object SaveState();
    void LoadState(object state);
}
