using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiddleSectionPanel : LobbyPanelBase
{
    [Header("MiddleSectionPanel Vars")]
    [SerializeField] private Button joinRandomRoomBtn;
    [SerializeField] private Button joinRoomByArgBtn;
    [SerializeField] private Button createRoomBtn;

    [SerializeField] private TMP_InputField joinRoomByArgInputField;
    [SerializeField] private TMP_InputField createRoomInputField;
    private NetworkRunnerContorller networkRunnerContorller;

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        networkRunnerContorller = GlobalManagers.Instance.NetworkRunnerController;
        joinRandomRoomBtn.onClick.AddListener(JoinRandomRoom);
        joinRoomByArgBtn.onClick.AddListener(() => CreateRoom(GameMode.Client, joinRoomByArgInputField.text));
        createRoomBtn.onClick.AddListener(() => CreateRoom(GameMode.Host, createRoomInputField.text));
    }

    private void CreateRoom(GameMode mode, string field)
    {
        if (createRoomInputField.text.Length >= 2)
        {
            Debug.Log($"-----------{mode}-----------");
            networkRunnerContorller.StartGame(mode, field);
        }
    }


    private void JoinRandomRoom()
    {
        Debug.Log($"-----------JoinRandomRoom-----------");
        networkRunnerContorller.StartGame(GameMode.AutoHostOrClient, string.Empty);

    }
}
