using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Win : MonoBehaviour
{
    Bank bank;
    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
    }
    
    public void GetClearPoint()
    {
        if(bank != null)
        {
            bank.ClearPoint();
        }
        Destroy(gameObject);
    }

}
