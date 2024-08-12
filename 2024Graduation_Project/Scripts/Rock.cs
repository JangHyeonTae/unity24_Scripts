using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] int penalty = 50;


    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void PenaltyPoint()
    {
        if (bank == null) { return; }
        bank.Withdraw(penalty);
        Destroy(this.gameObject);
    }
}
