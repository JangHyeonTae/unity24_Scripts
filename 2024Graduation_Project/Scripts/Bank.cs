using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bank : MonoBehaviour
{
    int startPoint = 0;
    int currentPoint;
    [SerializeField] TextMeshProUGUI displayBalance;
    public int CurrentPoint { get { return currentPoint; } }

    void Awake()
    {
        currentPoint = startPoint;
        UpdateDisplay();
    }
    public void Deposit(int point)
    {
        currentPoint += Mathf.Abs(point); 
        UpdateDisplay();
    }

    public void Withdraw(int point)
    {
        currentPoint -= Mathf.Abs(point);
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayBalance.text = "POINT: " + currentPoint;
    }
}
