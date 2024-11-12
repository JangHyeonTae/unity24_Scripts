using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Swipe : MonoBehaviour
{
    private Vector2 DownPosition;
    private Vector2 UpPosition;
    [SerializeField]
    private float minDistanceForSwipe = 20f;


    GyungPlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<GyungPlayerMovement>();

    }

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            if(touchPosition.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    DownPosition = touch.position;
                    UpPosition = touch.position;
                }

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    UpPosition = touch.position;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    UpPosition = touch.position;
                    CheckSwipe();

                }
            }
            
            
            //tap두번이상일시
            //if(touch.tapCount > 2)
            //{
            //    //PlayerMovement의 다른 player 잡기
            //}
        }
    }
    void CheckSwipe()
    {
        float deltaY = UpPosition.y - DownPosition.y;

        if (deltaY > minDistanceForSwipe)
        {
            if (deltaY > 0 ) // Up swipe
            {
                float jumpForce = deltaY;
                playerMovement.Jump(jumpForce);
            }
        }
    }
}