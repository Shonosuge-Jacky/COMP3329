using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class IsMine : MonoBehaviourPunCallbacks
{
    public GameObject camera;
    // public GameObject player;
    public GameObject ui;
    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            camera.SetActive(true);
            // player.SetActive(true);
            ui.SetActive(true);
        }
        else
        {
            camera.SetActive(false);
            // player.SetActive(false);
            ui.SetActive(false);
        }
    }
}
