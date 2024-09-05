using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    Bank bank;
    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
    }


}
