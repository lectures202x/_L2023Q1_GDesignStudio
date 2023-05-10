using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class Sample_Photon_FPS_NetworkManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        Screen.SetResolution(1280, 1024, false);

        // 게임에서 사용할 사용자의 이름을 랜덤으로 생성함
        int num = Random.Range(0, 1000);
        PhotonNetwork.NickName = "Player " + num;

        print("Starting Connect Process...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() => PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player1A", Vector3.zero, Quaternion.identity);
    }


}
