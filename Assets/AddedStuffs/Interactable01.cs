using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactable01 : MonoBehaviourPunCallbacks
{
    public GameObject theSupply;
    public GameObject Object001;
    public void active()
    {   
        photonView.RPC("activerpc",RpcTarget.All);
    }

    [PunRPC] 
    public void activerpc()
    {   
        Object001.GetComponent<MeshCollider>().enabled=true;
        theSupply.GetComponent<Animation>().Play("Crate_Open");
    }
}
