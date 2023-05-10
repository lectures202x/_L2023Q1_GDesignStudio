using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ShootingGame_NetworkManager : MonoBehaviourPunCallbacks
{

    public string PlayerName;
    string PlayerPrefabName = "MultiPlayer_Photon_ShootingGame_Player";

    void Start()
    {
        Screen.SetResolution(800, 600, false); // fullscreen = false

        // 게임에서 사용할 사용자의 이름을 설정함
        if (string.IsNullOrEmpty(PlayerName)) PlayerName = "Player " + Random.Range(0, 1000);
        PhotonNetwork.NickName = PlayerName;
        print("Player Name: " + PhotonNetwork.NickName);

        // 접속 시작
        print("Starting Connect Process...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected To Master");
        RoomOptions ro = new RoomOptions()
        {
            MaxPlayers = 8
        };
        // 게임 서버에 접속함. 성공하면 OnJoinedRoom()가 자동 호출됨
        PhotonNetwork.JoinOrCreateRoom("Room", ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print(PhotonNetwork.NickName + " has joined Room");
        Vector2 originPos = Random.insideUnitCircle * 10.0f;
        PhotonNetwork.Instantiate(PlayerPrefabName, new Vector3(originPos.x, 0, originPos.y), Quaternion.identity);
    }
}
