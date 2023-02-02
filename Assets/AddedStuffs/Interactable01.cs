using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactable01 : MonoBehaviourPunCallbacks
{
    // public GameObject theSupply;
    // public GameObject Object001;
    public int theSupply=0;
    public int Object001=0;
    public void active()
    {   
        theSupply=1;
        Object001=1;
        // Object001.GetComponent<MeshCollider>().enabled=true;
        // theSupply.GetComponent<Animation>().Play("Crate_Open");
    }
}
