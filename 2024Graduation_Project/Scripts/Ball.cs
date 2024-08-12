using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 MovementScale;
    [SerializeField] float upScaleSize = 0.001f;
    [SerializeField] Vector3 ballVector = new Vector3(-0.001f,0,0);

    PlayerMovement movement;
    BallCrash crash;

    Vector3 startScale;
    Vector3 startPosition;

    public bool isTriggered =false;
    //public bool pointTriggered = false;

    Rock rock;
    Bank bank;
    [SerializeField] int pointUp = 1;
    [SerializeField] int bumpPoint = 5;
    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
        crash = GetComponent<BallCrash>();
        bank = FindObjectOfType<Bank>();
        rock = FindObjectOfType<Rock>();

        startScale = new Vector3(0.5f, 0.5f, 0.5f);
        startPosition = new Vector3(0, 0.1f, 1);

        gameObject.transform.localScale = startScale;
    }

    void FixedUpdate()
    {
        if (gameObject != null)
        {
            MovementScale = movement.InputDirection();

            if(gameObject.transform.localScale.x < startScale.x)
            {
                gameObject.transform.localScale = startScale;
                gameObject.transform.localPosition = startPosition;
            }
            else if (isTriggered == true)
            {
                MinusScale();
                rock.PenaltyPoint();
                isTriggered = false;
            }

            if (MovementScale.magnitude > upScaleSize)
            {
                UpScaling();
                //transform.localRotation = Quaternion.Euler(MovementScale);
                RewardPoint();
            } 

            //if(pointTriggered == true)
            //{
            //    PointScaling();
            //    pointTriggered = false;
            //    bank.Deposit(bumpPoint);
            //}

        }
    }

    //void PointScaling()
    //{
    //    gameObject.transform.localScale += new Vector3(5, 5, 5);
    //}

    public void RewardPoint()
    {
        if (bank == null) { return; }
        bank.Deposit(pointUp);
    }
    void UpScaling()
    {
        Vector3 ScaleSize = new Vector3(Mathf.Abs(upScaleSize), Mathf.Abs(upScaleSize), Mathf.Abs(upScaleSize));
        Vector3 upSize = ScaleSize;
        transform.Translate(upSize / 1.3f + ballVector);
        Scaling(upSize);
    }

    void MinusScale()
    {
        Vector3 MinusScaleSize = new Vector3(5, 5, 5);
        MinusScaling(MinusScaleSize);
    }

    void Scaling(Vector3 newScale)
    {
        transform.localScale += newScale;
    }

    void MinusScaling(Vector3 newMinusScale)
    {
        transform.localScale -= newMinusScale;
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rock")
        {
            isTriggered = true;
        }
        ///else if(other.tag == "Point")
        ///{
        ///    pointTriggered = true;
        ///}
    }
}
