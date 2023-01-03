using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crane_scr : MonoBehaviour
{   //vars
    // speeds
    public float turnSpeed=5;             // rate at which the crane can rotate on the Y axis
    public float hookVerticalSpeed=5;     // rate at which the hook can be raised and lowered
    public float hookHorizontalSpeed = 5;   // rate at which the hook can be moved horizontally along the crane
    // hook
    protected float hookRaiseLimit = 0;        // the highest the hook can be raised
    protected float hookLowerLimit = -14;        // the lowest the hook can be lowered
    protected float hookForwardsLimit = -13;     // the furthest forward the hook can be moved
    protected float hookBackwardsLimit = -3;    // the furthest backwards the hook can be moved
    // components
    public GameObject craneTop;         // top of the crane which rotates
    public GameObject hook;             // the hook object

    public int totalScore = 0;
    public Text TotalScoretext;


    // Start is called before the first frame update
    void Start()
    {
        TotalScoretext.text = "Total Score: " + totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        #region MovementInput
        if (Input.GetKey(KeyCode.E))
            TurnClockwise();
        if (Input.GetKey(KeyCode.Q))
            TurnAntiClockwise();
        if (Input.GetKey(KeyCode.W))
            RaiseHook();
        if (Input.GetKey(KeyCode.S))
            LowerHook();
        if (Input.GetKey(KeyCode.A))
            MoveHookForward();
        if (Input.GetKey(KeyCode.D))
            MoveHookBackwards();
        #endregion

    }

    #region MovementMethods
    //methods
    // rotates the crane clockwise along the Y axis
    public void TurnClockwise()
    {
        craneTop.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
    // rotates the crane anti-clockwise along the Y axiss
    public void TurnAntiClockwise()
    {
        craneTop.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }
    // moves the hook down
    public void LowerHook()
    {
        if (hook.transform.localPosition.y > hookLowerLimit)
        {
            hook.transform.localPosition += Vector3.down * hookVerticalSpeed * Time.deltaTime;
        }
    }
    // moves the hook up
    public void RaiseHook()
    {
        if (hook.transform.localPosition.y < hookRaiseLimit)
        {
            hook.transform.localPosition += Vector3.up * hookVerticalSpeed * Time.deltaTime;
        }
    }
    // moves the hook forwards horizontally along the crane
    public void MoveHookForward()
    {
        if (hook.transform.localPosition.x > hookForwardsLimit)
        {
            hook.transform.localPosition += Vector3.left * hookHorizontalSpeed * Time.deltaTime;
        }
    }
    // moves the hook backwards horizontally along the crane
    public void MoveHookBackwards()
    {
        if (hook.transform.localPosition.x < hookBackwardsLimit)
        {
            hook.transform.localPosition += Vector3.right * hookHorizontalSpeed * Time.deltaTime;
        }
    }
    #endregion


    #region ScoreMethods
    public void AddScore(int scoreinput) {
        totalScore+= scoreinput;
        TotalScoretext.text = "Total Score: " + totalScore;
    }

    #endregion
}
