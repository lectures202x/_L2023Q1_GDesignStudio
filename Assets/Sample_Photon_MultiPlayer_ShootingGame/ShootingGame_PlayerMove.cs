using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingGame_PlayerMove : MonoBehaviourPunCallbacks
{
    void Update()
    {
        if (photonView.IsMine)
        {
            float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 500f;
            float v = Input.GetAxisRaw("Vertical") * Time.deltaTime * 3f;
            transform.Rotate(0, h, 0);
            transform.Translate(0, 0, v);
        }

        if(transform.position.y < -5)
        {
            Vector2 originPos = Random.insideUnitCircle * 2.0f;
            transform.position = new Vector3(originPos.x, 0, originPos.y);
            Vector3 randomForward = Random.insideUnitSphere.normalized;            
            Vector3 randomDir = new Vector3(randomForward.x, 0, randomForward.z);
            transform.rotation = Quaternion.LookRotation(randomDir);
        }
    }
}
