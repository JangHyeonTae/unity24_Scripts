using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] int penalty = 500;
    

    public void PenaltyPoint()
    {
        Bank bank = GetComponent<Bank>();
        if (bank == null) { return; }
        bank.Withdraw(penalty);
        Destroy(this.gameObject);
        Debug.Log("point down");
    }
}
