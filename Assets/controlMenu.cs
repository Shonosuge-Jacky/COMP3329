using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class controlMenu : MonoBehaviourPunCallbacks
{
    public GameObject CtMenu;
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                CtMenu.active=true;
            }
            else
            {
                CtMenu.active=false;
            }
        }
    }
}
