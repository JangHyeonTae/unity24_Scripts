using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] int point = 500;

    public void GetPoint()
    {
        Bank bank = GetComponent<Bank>();
        if (bank == null) { return; }
        bank.Deposit(point);
        Destroy(this.gameObject);
        Debug.Log("point up");
    }
}
