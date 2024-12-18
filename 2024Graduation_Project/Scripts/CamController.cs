using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float rotationSpeed = 0.2f;
    private float rotationY =0f;
    public  GameObject target;

    public float RotationY => rotationY;
    void Start()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotationY = rotation.y;
    }

    void Update()
    {
        if(Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            if(touchPosition.x > Screen.width / 2)
            {
                if(touch.phase == TouchPhase.Moved)
                {
                    rotationY += touch.deltaPosition.x * rotationSpeed;
                    target.transform.localEulerAngles = new Vector3(0f,rotationY,0f);
                }
            }
        }
    }
}
