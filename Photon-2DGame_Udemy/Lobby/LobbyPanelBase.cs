using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPanelBase : MonoBehaviour
{
    [field: SerializeField, Header("LobbyPlaneBase Vars")]
    public LobbyPanelType PanelType { get; private set; }
    [SerializeField] private Animator panelAnimator;

    protected LobbyUIManager lobbyUIManager;
    public enum LobbyPanelType
    {
        None,
        CreateNicknamePanel,
        MiddleSectionPanel
    }

    public virtual void InitPanel(LobbyUIManager uiManager)
    {
        lobbyUIManager = uiManager;
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
        const string POP_IN_CLIP_NAME = "IN";
        panelAnimator.Play(POP_IN_CLIP_NAME);
    }

    protected void ClosePanel()
    {
        const string POP_OUT_CLIP_NAME = "OUT";
        CallAnimationCoroutine(POP_OUT_CLIP_NAME, false);
    }

    private void CallAnimationCoroutine(string clipName, bool state)
    {
        StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject, panelAnimator, clipName, state));
    }
}
