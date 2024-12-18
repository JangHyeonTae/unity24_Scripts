using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterClientChangeScript : MonoBehaviour
{
    //1. master함수 생성후 사용방법
    public bool master()
    {
        return PhotonNetwork.LocalPlayer.IsMasterClient;
    }

    //2.
    //복잡한 계산할때 유용한 방법 -> 모든 계산을 master에게 넘기고 방장 혼자 계산후 다른 사람에게 전달
    //장점 : 모두 동기화 필요없이 방장만 값을 계산하면됨
    //void Click()
    //{
    //    PV.RPC("MasterReceiveRPC", RpcTarget.MasterClient);
    //}

    //[PunRPC]
    //void MasterReceiveRPC()
    //{
    //      //방장이 계산
    //    PV.RPC("OtherReceiveRPC", RpcTarget.Others);
    //}

    //[PunRPC]
    //void OtherReceiveRPC()
    //{

    //}



    //3. JSON이란??
    //JSON을 쓰는이유 -> 클래스리스트는 포톤 직렬화 가능한 형식에 없기 때문



    //4.Ownership change
    //방장 넘기기 - photonview component에서
    //fixed: 생성된 게임 오브젝트에서 주인이 안바뀜,
    //TakeeOver: 누구나 쉽게 방장 전달가능,
    //Request: 현재 주인에게 소윺권을 요청 할 수 있으나 거절 될 수있음

    //TakeOver일경우: 
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        BallPV.RequestOwnership(); //자기가 주인이됨
    //        BallPV.TransferOwnership(PhotonNetwork.PlayerListOthers[0]); // 해당 플레이어가 주인이 됨
    //    }
    //    if(BallPV.Owner == PhotonNetwork.LocalPlayer)
    //    {
    //        BallPV.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * 2, 0, 0));
    //    }
    //}

    //인터페이스 상속과 구현
    //public class MasterClientChangeScript : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
    //{
    //    public void OnOwnershipRequest(PhotonView targetView, Player requestinPlayer)
    //    {
    //        print("요청"); //->BallPV.RequestOwnership()
    //    }
    //    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    //    {
    //        print("옮겨짐");//->BallPV.TransferOwnership()
    //    }
    //}



    //5. Request일경우:
    //public override void OnJoinedRoom()
    //{
    //    PlayerPV = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity).GetPhotonView();
    //}
    
    //PhotonView FindPlayer()
    //{
    //    foreach(var player in GameObject.FindGameObjectsWithTag("Player"))
    //    {
    //        if (player.GetPhotonView().Owner != PhotonNetwork.LocalPlayer) return player.GetPhotonView();
    //    }
    //    return null;
    //}
    //void Update()
    //{
    //    if (Input.GetAxisDown(KeyCode.Alpha1))
    //    {
    //        FindPlayer().RequestOwnership();
    //    }
    //}

    //public class MasterClientChangeScript : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
    //{
    //    public void OnOwnershipRequest(PhotonView targetView, Player requestinPlayer)
    //    {
    //        targetView.TransferOwnership(requestingPlayer);
    //    }
    //}

}
