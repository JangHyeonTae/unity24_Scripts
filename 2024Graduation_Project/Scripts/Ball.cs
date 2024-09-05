using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 MovementScale;
    [SerializeField] float upScaleSize = 0.001f;
    [SerializeField] Vector3 ballVector = new Vector3(-0.001f,0,0);
    [SerializeField] Vector3 PointUpMove = new Vector3(0, 0, 1);

    PlayerMovement movement;

    Vector3 startScale;
    Vector3 startPosition;

    public bool isTriggered =false;
    public bool pointTriggered = false;

    Bank bank;
    //private InstantiateCreate instant;
    [SerializeField] int pointUp = 1;
    [SerializeField] int bumpPoint = 1;

    void Awake()
    {
        //싱글톤 공부
        movement = FindObjectOfType<PlayerMovement>();
        //FindObjectOfType -> singleton or FindWithTag
        bank = FindObjectOfType<Bank>();
    }
    void Start()
    {
        startScale = new Vector3(0.5f, 0.5f, 0.5f);
        startPosition = new Vector3(0, 0.1f, 1);

        gameObject.transform.localScale = startScale;
    }

    void Update()
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
            //gameObject.transform.rotation = Quaternion.Euler()
        }
    }

    public void PointScaling()
    {
        if(bank == null) { return; }
        gameObject.transform.localScale += new Vector3(bumpPoint,bumpPoint,bumpPoint);
        bank.Deposit(bumpPoint);
    }

    //Bank script에 pointup 할당
    public void RewardPoint()
    {
        if (bank == null) { return; }
        bank.Deposit(pointUp);
    }

    //움직일경우 눈 크기 커지는 함수
    void UpScaling()
    {
        //크기 작아질때는 실행 되지 않도록 설정
        if(isTriggered == false)
        {
            Vector3 ScaleSize = new Vector3(Mathf.Abs(upScaleSize)/10, Mathf.Abs(upScaleSize)/10, Mathf.Abs(upScaleSize)/10);
            Vector3 upSize = ScaleSize;
            transform.Translate(upSize / 1.3f + ballVector);
            Scaling(upSize);
        }
        
    }

    //스케일키우는함수
    void Scaling(Vector3 newScale)
    {
        transform.localScale += newScale;
    }

    //돌과 충돌시 (5,5,5)만큼의 크기 줄이는함수
    public void MinusScale()
    {
        Vector3 MinusScaleSize = new Vector3(5, 5, 5);
        MinusScaling(MinusScaleSize);
    }
    //스케일 줄이는 함수로 MinusSclae에서 Vector3받아옴
    public void MinusScaling(Vector3 newMinusScale)
    {
        transform.localScale -= newMinusScale;
    }

    public void FinishFunction()
    {
        TransPoint();
    }

    public void TransPoint()
    {
        
    }

   void OnTriggerEnter(Collider other)
   {
       Rock rock = other.gameObject.GetComponent<Rock>();
       Point point = other.gameObject.GetComponent<Point>();
       Win win = other.gameObject.GetComponent<Win>();
      
       switch (other.tag)
       {
           case "Rock":
               MinusScale();
               rock.PenaltyPoint(); 
                transform.Translate(-PointUpMove);
                break;
           case "Point":
               PointScaling();
               point.GetPoint();
                transform.Translate(PointUpMove);
                break;
           case "Finish":
               FinishFunction();
               break;
           default:
               break;
       }
   }
}