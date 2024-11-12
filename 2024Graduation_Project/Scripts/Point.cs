using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Point : MonoBehaviour
{
    [SerializeField] int point;
    [SerializeField] TextMeshPro display;
    [SerializeField] GameObject pointParticle;

    Bank bank;
    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
        point = Random.Range(1, 5) * 100;
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void GetPoint()
    {
        if (bank != null)
        {
            bank.Deposit(point);
        }

        if (pointParticle != null)
        {
            PhotonNetwork.Instantiate(pointParticle.name, transform.position, Quaternion.identity);

        }

        PhotonNetwork.Destroy(this.gameObject);
    }

    void UpdateDisplay()
    {
        display.text = "+" + point;
    }
}
