using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SnowCollision : MonoBehaviour
{
    GyungPlayerMovement movement;
    Ball ball;
    PhotonView photonView;

    void Start()
    {
        movement = FindObjectOfType<GyungPlayerMovement>();
    }

    [PunRPC]
    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                PhotonNetwork.Destroy(this.gameObject);
                movement.Catch();
            }
        
    }
}
