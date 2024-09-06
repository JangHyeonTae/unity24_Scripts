using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bank : MonoBehaviour
{
    int startPoint = 0;
    int currentPoint;
    int getPoint;
    int getcurrentPoint;
    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] TextMeshProUGUI windisplayBalance;
    public int CurrentPoint { get { return currentPoint; } }

    void Awake()
    {
        currentPoint = startPoint;
        getPoint = startPoint;
        UpdateDisplay();
        UpdateWinDisplay();
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
        if(currentPoint < startPoint)
        {
            currentPoint = startPoint;
        }
    }

    public void ClearPoint()
    {
        getcurrentPoint = currentPoint;
        Withdraw(currentPoint);
        getPoint += Mathf.Abs(getcurrentPoint);
        UpdateWinDisplay();
    }

    void UpdateDisplay()
    {
        displayBalance.text = "POINT: " + currentPoint;
    }

    void UpdateWinDisplay()
    {
        windisplayBalance.text = "GOAL: " + getPoint;
    }
}
