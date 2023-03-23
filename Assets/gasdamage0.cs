using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

// User -> PlayerCam
public class gasdamage0 : MonoBehaviourPunCallbacks
{
    private int dead=0;
    private float interactRange = 6f;
    public DestructibleP destP;
    // public startButton startButton;

    // Update is called once per frame
    void Update()
    {
        // Gas damage
        Collider[] colliderArray2 = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider2 in colliderArray2)
        {
            if (collider2.TryGetComponent(out gasdamage gasdamage) && dead==0)
            {
                // Destory this player in all player's view
                dead=1;
                // startButton.killbyG();
                destP.killbyG();
                destP.Destroy();
            }
        }    
    }
}
