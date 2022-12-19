using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pullable_script : MonoBehaviour
{
    protected Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
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
          
            rb.useGravity = false;
            rb.isKinematic = true;

            transform.position = other.transform.GetChild(1).position;
            //transform.parent = other.transform;
        }
    }
}
