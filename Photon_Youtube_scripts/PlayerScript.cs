using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviourPun, IPunObservable
{
    public int value, valuePerClick, clickUpgradeCost, clickUpgradeAdd, autoUpgradeCost, 
        autoUpgradeAdd, valuePerSecond;
    NetworkManager manager;
    PhotonView PV;

    void Start()
    {
        manager = GameObject.FindWithTag("NetworkManager").GetComponent<NetworkManager>();
        PV = photonView;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(value);
        }
        else
        {
            value = (int)stream.ReceiveNext();
        }
    }

    void Update()
    {
        if (!PV.IsMine) return;
        manager.valueText.text = value.ToString();
    }
    

}
