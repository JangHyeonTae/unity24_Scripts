using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonCustomproperties : MonoBehaviour
{
    //1번 room형식: CustomProperties - 모든 player 태그 달기
    //방에 있을 때 누구나 현재 방(room 형식)에 누구나 태그를 달 수 있다.
    //키는 문자열이어야 하고 값은 포톤이 직렬화할 수 있는 여러 형식 가능
    //키에 다른 값을 덮을 수 있음
    //자동 형변환 안되므로 0과 0f구별
    //CustomProperties로 쓰지말고 SetCutomProperties로 사용 (CustomProperties 안될 경우 많음)

    //public override void OnJoinedRoom()
    //{
    //    PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "키1", "문자열" }, { "키2", 1 } });
    //    print(PhotonNetwork.CurrentRoom.CustomProperties["키1"]);
    //}


    //2번 Player형식: 

    //public override void OnJoinedRoom()
    //{
    //    PhotonNetwork.PlayerList[0].SetCustomProperties(new Hashtable() { { "키1", "문자열" }, { "키2", 1 } });
    //    print(PhotonNetwork.PlayerList[0].CustomProperties["키1"]);
    //}


    //3. 카트라이더 방만들기 예제
    
    //방 만든사람 0에 자기 번호, 참여가능 슬롯 0, 참여 분가능 슬롯 -1, 저장은 무조건 Set으로
    //If(S.Master)
    //{
    //    int max = PhotonNetwork.CurrentRoom.MaxPlayers - 1;

    //    PhotonNetwork.CurrentRoom.SetCustomProperties
    //        (new Hashtable
    //        {
    //            {"0", PhotonNetwork.LocalPlayer.ActorNumber }, {"1",0},
    //            {"2", 2 <= max ? 0 :-1}, {"3", 3 <= max ? 0 :-1},
    //            {"4", 4 <= max ? 0 :-1}, {"5", 5 <= max ? 0 :-1},
    //            {"6", 6 <= max ? 0 :-1}, {"7", 7 <= max ? 0 :-1}
    //        }
    //        );
    //}


    //4. 씬 전환시 동기화 로직
    //카트라이더의 씬동기화로직
    //일반적으로 씬 전환될 때 모든 Player가 씬이 전환되지 않는다 -> 해결하기위해 씬전환시 동기화 로직 필요
    //S -> SingleTon 
    //IEnumerator Loading해석 :
    //while(AllhasTag("loadScene")) -> 모든 플레이어들이 loadScene -> key 를 가지고 있다면 if문 실행
    //if(S.master()) -> 방장이라면 SpawnSettin()실행 -> 차들 생성
    //while(AllhasTag("loadPlayer)) -> 모든 차에대한 loadPlayer키 확인후 다음것 실행

    //public bool AllhasTag(string key)
    //{
    //    for(int i=0; i < PhotonNetwork.PlayerList.Length; i++)
    //    {
    //        if (PhotonNetwork.PlayerList[i].CustomProperties[key] == null)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    //IEnumerator Loading()
    //{
    //    while (!S.AllhasTag("loadScene")) yield return null;
    //    if (S.master()) SpawnSetting();
    //    while (!S.AllhasTag("loadPlayer")) yield return null;
    //}


}
