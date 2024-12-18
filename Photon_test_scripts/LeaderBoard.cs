using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using TMPro;
using Photon.Pun.UtilityScripts;

public class LeaderBoard : MonoBehaviour
{
    public GameObject playerHolder;

    [Header("Option")]
    public float refreshRate = 1f;

    [Header("UI")]
    public GameObject[] slots;

    [Space]
    public TextMeshProUGUI[] scoreTexts;
    public TextMeshProUGUI[] nameTexts;

    private void Start()
    {
        InvokeRepeating(nameof(Refresh), 1f, refreshRate);
    }

    //foreach를 사용ㅇ해 slot을 왜 false인지, sortedPlayerList 자체 이해안감
    public void Refresh()
    {
        foreach(var slot in slots)
        {
            slot.SetActive(false);
        }

        var sortedPlayerList = (from player in PhotonNetwork.PlayerList orderby player.GetScore() descending select player).ToList();

        int i = 0;
        foreach(var player in sortedPlayerList)
        {
            slots[i].SetActive(true);

            if(player.NickName == "")
            {
                player.NickName = "unnamed";
            }

            nameTexts[i].text = player.NickName;
            scoreTexts[i].text = player.GetScore().ToString();

            i++;
        }
    }

    private void Update()
    {
        playerHolder.SetActive(Input.GetKey(KeyCode.Tab));
    }
}
