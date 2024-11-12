using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Rock : MonoBehaviourPun
{
    [SerializeField] int penalty = 500;
    [SerializeField] GameObject bombParticle;

    Bank bank;
    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
    }



    [PunRPC]
    public void PenaltyPoint()
    {
        if (bank != null)
        {
            bank.Withdraw(penalty);
        }

        if(bombParticle != null)
        {
            PhotonNetwork.Instantiate(bombParticle.name, transform.position, Quaternion.identity);
        }

        PhotonNetwork.Destroy(this.gameObject);
    }

}
