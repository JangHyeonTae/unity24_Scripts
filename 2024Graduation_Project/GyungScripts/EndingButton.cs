using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class EndingButton : MonoBehaviour
{
    public GameObject LobbyExitButton;

    public void OnQuitMatchButtonClicked()
    {
        if(PhotonNetwork.InRoom){
            PhotonNetwork.LeaveRoom();
        }
        else
        {
            SceneManager.LoadScene("Lobby");
        }
    }
    
}
