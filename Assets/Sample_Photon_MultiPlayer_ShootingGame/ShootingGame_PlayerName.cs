using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ShootingGame_PlayerName : MonoBehaviourPunCallbacks //ptotonView needs MonoBehaviourPunCallbacks
{
    public TMP_Text PlayerName;
    public Transform Canvas;

    void Start()
    {
        print("NickName:" + photonView.Owner.NickName);
        PlayerName.text = photonView.Owner.NickName;
        gameObject.name = photonView.Owner.NickName;
        if (photonView.IsMine)
        {
            PlayerName.color = Color.green;
        }
        else
        {
            PlayerName.color = Color.red;
        }
    }

    void Update()
    {
        Canvas.forward = Camera.main.transform.forward;
    }
}
