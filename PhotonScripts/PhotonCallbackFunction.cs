using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonCallbackFunction : MonoBehaviourPunCallbacks
{
    public override void OnConnected()
    {
        //연결

        //PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //연결끊김
        //PhotonNetwork.Disconnect();
    }

    public override void OnConnectedToMaster()
    {
        //마스터서버 연결
        //Lobby or Room
        //PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnJoinedLobby()
    {
        //로비 참가
        //PhotonNetwork.JoinLobby();
    }

    public override void OnLeftLobby()
    {
        //로비 나감
        //PhotonNetwork.LeaveLobby();
    }

    public override void OnCreatedRoom()
    {
        //방 만들기

        //PhotonNetwork.CreateRoom("room", new RoomOptions { MaxPlayers = 2 }, null);
        //PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        //방 만들기 실해
    }

    public override void OnJoinedRoom()
    {
        //방 참가

        //PhotonNetwork.JoinRoom("room");
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // 방참가 실패
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //방 랜덤참가 실패
    }

    public override void OnLeftRoom()
    {
        //방 나감

        //PhotonNetwork.LeaveRoom();
    }

    public override void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
    {
        //여러 로비를 사용하고 싶으면 PhotonServerSettings -> Lobby statistics 활성화
        //마스터 서버에서 로비들의 정보를 볼 수 있음

        //PhotonNetwork.JoinLobby(new TypedLobby("dduck", LobbyType.Default));
        //for(int i = 0; i < lobbyStatistics.Count; i++)
        //{
        //    LogText.text += lobbyStatistics[i].Name + ", " + lobbyStatistics[i].PlayerCount + "\n";
        //}
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        //방에 있을 때, 방장이 바뀔 시

        //PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }

    //List<RoomInfo> myList = new List<RoomInfo>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //로비에 있을 때, 방 리스트 업데이트 시

        //int roomCount = roomList.Count;
        //for(int i =0; i<roomCount; i++)
        //{
        //    if (!roomList[i].RemovedFromList)
        //    {
        //        if (!myList.Contains(roomList[i])) myList.Add(roomList[i]);
        //        else myList[myList.IndexOf(roomList[i])] = roomList[i];
        //    }
        //    else if (myList.IndexOf(roomList[i]) != -1)
        //    {
        //        myList.RemoveAt(myList.IndexOf(roomList[i]));
        //    }
        //}
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        //방에 있을 때, 방 태그 변경시

        //PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable { { "Roomtag", "tag" } });
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        //방에 있을 때, 플레이어 태그 변경시

        //PhotonNetwork.PlayerList[0].SetCustomProperties(new Hashtable { { "PlayerTag", "tag" } });
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //방에 있을 때, 새로운 플레이어가 들어옴
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //방에 있을 때, 다른 플레이어가 나감
    }

}
