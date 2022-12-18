using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pullable_script : MonoBehaviour
{
    protected Rigidbody rb;
    protected Collider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        rb = gameObject.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            // attach to the hook
            col.enabled = false;
          
            rb.useGravity = false;
            transform.position = other.transform.Find("Hook_Grab_pos").position;
            transform.parent = other.transform;
        }
    }
}
