using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_scr : MonoBehaviour
{   
    //components
    public LineRenderer lineRenderer;
    public GameObject cableAnchorPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make the cable anchor follow us along the crane
        Vector3 newPos = cableAnchorPosition.transform.localPosition;
        newPos.x = transform.localPosition.x;
        cableAnchorPosition.transform.localPosition = newPos;
        // connect the line renderer from the cable anchor to us
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, cableAnchorPosition.transform.position);
    }
}
