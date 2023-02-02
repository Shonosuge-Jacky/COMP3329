using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MoveCamera : MonoBehaviourPunCallbacks
{
    public Transform cameraPosition;

    private void Update()
    {
        if (photonView.IsMine)
        {
            transform.position = cameraPosition.position;
        } 
    }

    // public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    // {
    //     if (stream.IsWriting)
    //     {
    //         //this is the local client
    //         stream.SendNext(pitch);
    //     }
    //     else
    //     {
    //         //this is the clone
    //         pitch = (float)stream.ReceiveNext();
    //     }
    // }
    
}
