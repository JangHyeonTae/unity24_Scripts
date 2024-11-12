using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviourPun
{
    PhotonView photonView;
    public Vector3 MovementScale;
    [SerializeField] float upScaleSize = 0.001f;
    [SerializeField] Vector3 ballVector = new Vector3(-0.001f,0,0);
    [SerializeField] Vector3 PointUpMove = new Vector3(0, 0, 1);
    [SerializeField] GameObject ballActive;
    GyungPlayerMovement movement;

    //Vector3 instantScale;
    Vector3 startScale = new Vector3(0.5f, 0.5f, 0.5f);
    Vector3 startPosition = new Vector3(0, 0.1f, 1);

    //public bool isTriggered =false;
    //public bool pointTriggered = false;

    Bank bank;
    //private InstantiateCreate instant;
    [SerializeField] int pointUp = 1;
    [SerializeField] int bumpPoint = 1;

    void Awake()
    {
        movement = FindObjectOfType<GyungPlayerMovement>();
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
            
            if (MovementScale.magnitude > upScaleSize)
            {
                UpScaling();
                //transform.localRotation = Quaternion.Euler(MovementScale);
                RewardPoint();
            }
            //gameObject.transform.rotation = Quaternion.Euler()
        }
        //if (photonView.IsMine)
        //{
        //  photonView.RPC("WorldBallActive", RpcTarget.All);
        //}
        WorldBallActive();
    }

    [PunRPC]
    public void WorldBallActive()
    {
        if(gameObject != null)
        {
            MovementScale = movement.InputDirection();

            if (gameObject.transform.localScale.x < startScale.x)
            {
                gameObject.transform.localScale = startScale;
                gameObject.transform.localPosition = startPosition;
                ballActive.gameObject.SetActive(false);
            }

        }
    }

    public void PointScaling()
    {
        if(bank == null) { return; }
        gameObject.transform.localScale += new Vector3(bumpPoint,bumpPoint,bumpPoint);
        bank.Deposit(bumpPoint);
    }

    [PunRPC]
    //Bank script�� pointup �Ҵ�
    public void RewardPoint()
    {
        if (bank == null) { return; }
        bank.Deposit(pointUp);
    }

    //�����ϰ�� �� ũ�� Ŀ���� �Լ�
    [PunRPC]
    void UpScaling()
    {
        //if(isTriggered == false)
        //{
            Vector3 ScaleSize = new Vector3(Mathf.Abs(upScaleSize)/10, Mathf.Abs(upScaleSize)/10, Mathf.Abs(upScaleSize)/10);
            Vector3 upSize = ScaleSize;
            transform.Translate(upSize / 1.3f + ballVector);
            Scaling(upSize);
        //}
        
    }

    //������Ű����Լ�
    void Scaling(Vector3 newScale)
    {
        transform.localScale += newScale;
    }

    //���� �浹�� (5,5,5)��ŭ�� ũ�� ���̴��Լ�
    [PunRPC]
    public void MinusScale()
    {
        Vector3 MinusScaleSize = new Vector3(5, 5, 5);
        MinusScaling(MinusScaleSize);
    }
    //������ ���̴� �Լ��� MinusSclae���� Vector3�޾ƿ�
    public void MinusScaling(Vector3 newMinusScale)
    {
        transform.localScale -= newMinusScale;
    }

    [PunRPC]
    public void GetPoint()
    {
        TransPoint();
    }

    public void TransPoint()
    {
        gameObject.transform.Translate(startPosition);
        gameObject.transform.localScale = startScale;
        ballActive.gameObject.SetActive(false);
    }

    [PunRPC]
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
            case "GetPoint":
                GetPoint();
                win.GetClearPoint();
                 break;
            case "Spin":
                ballActive.gameObject.SetActive(false);
                 break;
            default:
                break;
       }
   }
}