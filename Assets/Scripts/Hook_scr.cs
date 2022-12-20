using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_scr : MonoBehaviour
{   
    //components
    public LineRenderer lineRenderer;
    public GameObject cableAnchorPosition;
    public Rigidbody rb;
    public bool disengaged = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        Cable();

        if (Input.GetKeyDown(KeyCode.N)) {
            disengaged = !disengaged;
            Neutral(disengaged);
        }

    }

    public void Cable()
    {
        // make the cable anchor follow us along the crane
        Vector3 newPos = cableAnchorPosition.transform.localPosition;
        newPos.x = transform.localPosition.x;
        cableAnchorPosition.transform.localPosition = newPos;
        // connect the line renderer from the cable anchor to us
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, cableAnchorPosition.transform.position);
    }
    public void Neutral(bool disengaged)
    {
        if (disengaged == true) {
            rb.isKinematic = false;

        }
        else if (disengaged == false){
            rb.isKinematic = true;
        }

    }
}

