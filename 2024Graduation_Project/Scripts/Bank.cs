using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startPoint = 0;
    [SerializeField] int currentPoint;
    public int CurrentPoint { get { return currentPoint; } }

    void Awake()
    {
        currentPoint = startPoint;
    }
    public void Deposit(int point)
    {
        currentPoint += Mathf.Abs(point); 
    }

    public void Withdraw(int point)
    {
        currentPoint -= Mathf.Abs(point);
    }
}
