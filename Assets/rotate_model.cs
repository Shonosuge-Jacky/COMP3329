using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class rotate_model : MonoBehaviourPunCallbacks
{
    public Transform playerrotation;
    Quaternion quaternion;
    private void Update()
    {
        if (photonView.IsMine)
        {
            quaternion = playerrotation.rotation;
            float eulerY = quaternion.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, eulerY, 0);
        }
    }
}
