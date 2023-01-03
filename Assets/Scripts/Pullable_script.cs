using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class Pullable_script : MonoBehaviour
{
    protected Rigidbody rb;
    protected GameObject pb;

    protected int obj_score;
    
    public Text TypeScoretext;

    protected Crane_scr crane_script;
    protected GameObject crane;



    [SerializeField] private Obj_Type obj_Type;
    enum Obj_Type
    {
        Madera,Concreto,Otros
    }

    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();

        crane = GameObject.FindGameObjectWithTag("Player");
        crane_script = crane.gameObject.GetComponent<Crane_scr>();


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

            TypeScoretext.text = "T: "+obj_Type+" / Score: "+obj_score;
        }
        else
        {   
            rb.useGravity = true;
            rb.isKinematic = false;
            TypeScoretext.text = "T: N" + " / Score: N";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score Zone"))
        {
            crane_script.AddScore(obj_score);
        }
    }

    public int ScorePoints() 
    {
        switch (obj_Type)
        {
            case Obj_Type.Madera:
                return obj_score = 15;
            case Obj_Type.Concreto:
                return obj_score = 35;
            case Obj_Type.Otros:
                return obj_score = 5;
            default:
                return obj_score = 0;
        }
    }
}