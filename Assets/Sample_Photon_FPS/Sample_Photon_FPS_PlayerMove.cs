using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class Sample_Photon_FPS_PlayerMove : MonoBehaviourPunCallbacks
{
    Transform Shape; // visual game object

    private void Start()
    {
        print("NickName:" + PhotonNetwork.NickName);
        print("PlayerList:" + PhotonNetwork.PlayerList);
        Shape = transform.Find("Capsule").Find("Cylinder");
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            //float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 500f;
            float v = Input.GetAxisRaw("Vertical") * Time.deltaTime * 3f;
            float mh = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 500f;
            float mv = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 500f;
            //mv = Mathf.Clamp(mv, 120, 60);

            transform.Translate(0, 0, v);
            transform.Rotate(0, mh, 0);
            ////transform.Rotate(0, mh, 0);
            //float eulerY = transform.eulerAngles.y + mv;
            //eulerY = Mathf.Clamp(eulerY, 0, 120);
            //print(eulerY);
            //Shape.transform.eulerAngles = new Vector3(transform.eulerAngles.x, eulerY, transform.eulerAngles.z);
            //print(mv);
            print(Shape.transform.eulerAngles);
            Shape.transform.Rotate(Vector3.right, -mv, Space.Self);
            //float eulerX = Mathf.Clamp(transform.eulerAngles.x, 60, 90);
            //Shape.transform.eulerAngles = new Vector3(eulerX, transform.eulerAngles.y, transform.eulerAngles.z);

            
        }
    }
}
