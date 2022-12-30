using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pullable_script : MonoBehaviour
{
    protected Rigidbody rb;
    protected GameObject pb;
    protected int Obj_score;

    [SerializeField] private Obj_Type obj_Type;

    enum Obj_Type
    {
        Madera,Concreto,Otros
    }

    // Start is called before the first frame update
    void Start()
    {
        pb = GameObject.Find("Physic_obj");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ScorePoints();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hook") && Input.GetKey(KeyCode.Space))
        {
            // attach to the hook
          
            rb.useGravity = false;
            rb.isKinematic = true;

            transform.position = other.transform.GetChild(1).position;
            //transform.parent = other.transform;
            Debug.Log("Ptje: "+Obj_score+" tipo: "+obj_Type);
        }
        else
        {   
            

            
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }



    private void ScorePoints() 
    {
        switch (obj_Type)
        {
            case Obj_Type.Madera:
                Obj_score = 15;
                break;
            case Obj_Type.Concreto:
                Obj_score = 35;
                break;
            case Obj_Type.Otros:
                Obj_score = 5;
                break;

            default:
                break;
        }
    }
}