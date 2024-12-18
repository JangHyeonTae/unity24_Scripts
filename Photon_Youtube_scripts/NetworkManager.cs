using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [Header("DisconnectedPanel")]
    public GameObject DisconnectedPanel;
    public InputField NicknameInput;
    public GameObject RoomPanel;

    public Text valueText, PlayerText, clickUpgradeText, autoUpgradeText,
        valuePerClickText, valuePerSecondText;
    public Button clickUpgradeBtn, autoUpgradeBtn;

    public float nextTime;

    void Start()
    {
        Screen.SetResolution(540, 960, false);
       
    }

    public void Connect()
    {
        PhotonNetwork.LocalPlayer.NickName = NicknameInput.text;
        PhotonNetwork.ConnectUsingSettings(); //photonNetwork 서버에 참여
    }

    public override void OnConnectedToMaster() //마스터 서버나 로비에 접속시 방에 참가가능 -> 이렇게 callback시 OnJoinedRoom으로 이동
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 5 }, null);
    }

    public override void OnJoinedRoom()
    {
        ShowPanel(RoomPanel);
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }

    void ShowPanel(GameObject CurPanel)
    {
        DisconnectedPanel.SetActive(false);
        RoomPanel.SetActive(false);
        CurPanel.SetActive(true);
    }


    PlayerScript FindPlayer()
    {
        foreach (GameObject Player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (Player.GetPhotonView().IsMine)
            {
                return Player.GetComponent<PlayerScript>();
            }
        }
        return null;
    }
    public void Click()
    {
        PlayerScript player = FindPlayer();
        player.value += player.valuePerClick;
    }

    public void ClickUpgrade()
    {
        PlayerScript player = FindPlayer();
        if(player.value >= player.clickUpgradeCost)
        {
            player.value -= player.clickUpgradeCost;
            player.valuePerClick += player.clickUpgradeAdd;
            player.clickUpgradeCost += player.clickUpgradeAdd * 10;
            player.clickUpgradeAdd += 2;

            clickUpgradeText.text = "비용 : " + player.clickUpgradeCost + "\n+" + player.clickUpgradeAdd + " / 클릭";
            valuePerClickText.text = player.valuePerClick.ToString();
        } 
    }

    public void AutoUpgrade()
    {
        PlayerScript player = FindPlayer();
        if (player.value >= player.autoUpgradeCost)
        {
            player.value -= player.autoUpgradeCost;
            player.valuePerSecond += player.autoUpgradeAdd;
            player.autoUpgradeCost += player.autoUpgradeAdd + 500;
            player.autoUpgradeAdd += 2;

            autoUpgradeText.text = "비용 : " + player.autoUpgradeCost + "\n+" + player.autoUpgradeAdd + " / 초";

            valuePerSecondText.text = player.valuePerSecond.ToString();
        }
    }

    void ShowPlayer()
    {
        string playerText = "";
        foreach(GameObject Player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerText += Player.GetPhotonView().Owner.NickName + " / " +  
                Player.GetComponent<PlayerScript>().value.ToString() + "\n";
        }
        PlayerText.text = playerText;
    }

    void EnavleUpdate()
    {
        PlayerScript player = FindPlayer();
        clickUpgradeBtn.interactable = player.value >= player.clickUpgradeCost;
        autoUpgradeBtn.interactable = player.value >= player.clickUpgradeCost;
    }

    void ValuePerSecond()
    {
        PlayerScript player = FindPlayer();
        player.value += player.valuePerSecond;
    }

    void Update()
    {
        if (!PhotonNetwork.InRoom) return;

        EnavleUpdate();
        ShowPlayer();

        if(Time.time > nextTime)
        {
            nextTime = Time.time + 1;
            ValuePerSecond();
        }
    }
}
