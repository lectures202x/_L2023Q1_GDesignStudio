using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingGame_Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("bullet hits " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            print("bullet collider disabled");
            print("damage " + other.gameObject.name);
            PhotonView pv = other.GetComponent<PhotonView>();
            pv.RPC("Damage", RpcTarget.AllBuffered, 0.1f);
        }
        Destroy(gameObject);
    }
}
