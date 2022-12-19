using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pullable_script : MonoBehaviour
{
    protected Rigidbody rb;
    protected GameObject pb;

    // Start is called before the first frame update
    void Start()
    {
        pb = GameObject.Find("Physic_obj");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hook")&& Input.GetKey(KeyCode.Space))
        {
            // attach to the hook
          
            rb.useGravity = false;
            rb.isKinematic = true;

            transform.position = other.transform.GetChild(1).position;
            //transform.parent = other.transform;
        }
        else
        {   
            

            
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
