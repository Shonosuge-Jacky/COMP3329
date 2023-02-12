using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class interactToPlater : MonoBehaviourPunCallbacks
{
    private int SupplyState=1;
    public GameObject theSupplytest;
    public GameObject Object001test;
    //==================================
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            float interactRange = 1f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out openSupply openSupply) && SupplyState==1)
                {
                    SupplyState=0;
                    photonView.RPC("opensupplynow",RpcTarget.All);
                }        
            }
        }
    }
    
    [PunRPC] 
    public void opensupplynow()
    {
        Object001test.GetComponent<MeshCollider>().enabled=true;
        theSupplytest.GetComponent<Animation>().Play("Crate_Open");
    }
}
