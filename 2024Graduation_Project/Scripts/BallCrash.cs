using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCrash : MonoBehaviour
{

    public bool isTriggered = false;
    void Start()
    {

    }
    public void MinusScale(Vector3 newMinusScale)
    {
        transform.localScale -= newMinusScale;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            isTriggered = true;
        }
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    switch (other.gameObject.tag)
    //    {
    //        case "Rock":
    //            Vector3 MinusScaleSize = new Vector3(Mathf.Abs(downScaleSize), Mathf.Abs(downScaleSize), Mathf.Abs(downScaleSize));
    //            MinusScale(MinusScaleSize);
    //            break;
    //        case "Finish":
    //            movement.Finish();
    //            break;
    //        case "otherBall":
    //            Debug.Log("crash other Ball");
    //            //OtherBall();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //void OtherBall()
    //{
    //    Vector3 MinusScaleSize = new Vector3(Mathf.Abs(downScaleSize), Mathf.Abs(downScaleSize), Mathf.Abs(downScaleSize));
    //    MinusScale(MinusScaleSize);
    //}
}
