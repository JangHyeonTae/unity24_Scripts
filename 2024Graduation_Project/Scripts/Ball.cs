using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 MovementScale;
    [SerializeField] float upScaleSize = 0.001f;
    [SerializeField] Vector3 ballVector = new Vector3(-0.001f,0,0);

    PlayerMovement movement;

    Vector3 startScale;
    Vector3 startPosition;

    public bool isTriggered =false;
    public bool pointTriggered = false;

    Rock rock;
    Bank bank;
    Point point;
    //private InstantiateCreate instant;
    [SerializeField] int pointUp = 1;
    [SerializeField] int bumpPoint = 5;
    void Start()
    {
        //싱글톤 공부
        movement = FindObjectOfType<PlayerMovement>();
        //FindObjectOfType -> singleton or FindWithTag
        bank = FindObjectOfType<Bank>();
        rock = FindObjectOfType<Rock>();
        point = FindAnyObjectByType<Point>();
       // instant = GameObject.Find("SpawnManager").GetComponent<InstantiateCreate>();

        startScale = new Vector3(0.5f, 0.5f, 0.5f);
        startPosition = new Vector3(0, 0.1f, 1);

        gameObject.transform.localScale = startScale;
    }

    void Update()
    {
        if(gameObject != null)
        {
            if (isTriggered == true)
            {
                MinusScale();
                rock.PenaltyPoint();
                isTriggered = false;
            }
            else if (pointTriggered == true)
            {
                PointScaling();
                point.GetPoint();
                pointTriggered = false;
                
            }
        }
        
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
            
            if (MovementScale.magnitude > upScaleSize)
            {
                UpScaling();
                //transform.localRotation = Quaternion.Euler(MovementScale);
                RewardPoint();
            }

            
        }
    }

    void PointScaling()
    {
        gameObject.transform.localScale += new Vector3(bumpPoint,bumpPoint,bumpPoint);
        bank.Deposit(bumpPoint);
    }

    public void RewardPoint()
    {
        if (bank == null) { return; }
        bank.Deposit(pointUp);
    }
    void UpScaling()
    {
        //크기 작아질때는 실행 되지 않도록 설정
        if(isTriggered == false)
        {
            Vector3 ScaleSize = new Vector3(Mathf.Abs(upScaleSize), Mathf.Abs(upScaleSize), Mathf.Abs(upScaleSize));
            Vector3 upSize = ScaleSize;
            transform.Translate(upSize / 1.3f + ballVector);
            Scaling(upSize);
        }
        
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


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Rock")
        {
            isTriggered = true;
        }
        else if (collision.collider.tag == "Point")
        {
            pointTriggered = true;
        }
    }
}
