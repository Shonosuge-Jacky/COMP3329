using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// public class PlayerCam : MonoBehaviourPunCallbacks, IPunObservable
public class PlayerCam : MonoBehaviourPunCallbacks
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        if (photonView.IsMine)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            // get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
            // print(transform.rotation);
            // print(orientation.rotation);
        }
    }

    // public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    // {
    //     if (stream.IsWriting)
    //     {
    //         //this is the local client
    //         stream.SendNext(yRotation);
    //         stream.SendNext(xRotation);
    //     }
    //     else
    //     {
    //         //this is the clone
    //         yRotation = (float)stream.ReceiveNext();
    //         xRotation = (float)stream.ReceiveNext();
    //     }
    // }
    
}