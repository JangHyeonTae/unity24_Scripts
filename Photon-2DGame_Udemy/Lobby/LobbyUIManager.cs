using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private LoadingCanvasController loadinCanvasContollerPrefab;

    [SerializeField] private LobbyPanelBase[] lobbyPanels;


    private void Start()
    {
        foreach (var lobby in lobbyPanels)
        {

            lobby.InitPanel(this);
        }

        Instantiate(loadinCanvasContollerPrefab);
    }

    public void ShowPanel(LobbyPanelBase.LobbyPanelType type)
    {
        foreach (var lobby in lobbyPanels)
        {
            if (lobby.PanelType == type)
            {
                lobby.ShowPanel();
                break;
            }
        }
    }
}
