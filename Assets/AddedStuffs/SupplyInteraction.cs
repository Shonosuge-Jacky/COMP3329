using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

using UnityEngine.UI;

public class SupplyInteraction : MonoBehaviourPunCallbacks
{
    private int SupplyState01 = 1;
    private int SupplyState02 = 1;
    private int dead = 0;
    public grenadeNumber redcount;
    public grenadeNumber yellowcount;
    public grenadeNumber yellowcount2;
    public grenadeNumber yellowcount3;
    public GameObject s1;
    public GameObject s2;
    public GameObject s;

    public GrenadeY GrenadeY;
    public GrenadeY2 GrenadeY2;
    public GrenadeY3 GrenadeY3;

    //==================================


    private void Update()
    {
        // if F is pressed and supply crate is within range
        // Update grenade count for current player, fade and destroy done in Interactable01.cs

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject supplyCrateOpened = null;
            if (photonView.IsMine)
            {
                float interactRange = 1f;
                Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

                // Check with supply crate (Interactable) is interacted with, and record as supplyCrateOpened
                // Currently, will always be Interactable01, because that's the script used for every crate
                foreach (Collider collider in colliderArray) // Assume impossible to interact w/ >1 crate
                {
                    if (collider.TryGetComponent(out Interactable01 Interactable01))
                    {
                        supplyCrateOpened = Interactable01.gameObject;
                        Debug.Log("crate opened");

                        Interactable01.active();
                        redcount.GetComponent<grenadeNumber>().count =
                            redcount.GetComponent<grenadeNumber>().count + 10;
                        if (yellowcount.GetComponent<grenadeNumberY>().count == " 0")
                        {
                            GrenadeY.upthrowed();
                            yellowcount.GetComponent<grenadeNumberY>().count = " 1";
                        }
                        if (yellowcount2.GetComponent<grenadeNumberY>().count == " 0")
                        {
                            GrenadeY2.upthrowed();
                            yellowcount2.GetComponent<grenadeNumberY>().count = " 1";
                        }
                        if (yellowcount3.GetComponent<grenadeNumberY>().count == " 0")
                        {
                            GrenadeY3.upthrowed();
                            yellowcount3.GetComponent<grenadeNumberY>().count = " 1";
                        }
                    }
                }
            }
        }
    }
}
