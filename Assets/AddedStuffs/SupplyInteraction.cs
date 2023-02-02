using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SupplyInteraction : MonoBehaviourPunCallbacks
{
    public int SupplyState01=1;
    public int SupplyState02=1;
    // public SupplyState supply01;
    // public SupplyState supply02;
    // public GameObject theSupply;
    // public GameObject theSupply2;
    // public GameObject Object001;
    // public GameObject Object002;
    public grenadeNumber redcount;
    // public Interactable01 Interactable01;
    // public Interactable02 Interactable02;
    //==================================
    private void Update()
    {
        if (photonView.IsMine)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                float interactRange = 1f;
                Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
                foreach(Collider collider in colliderArray)
                {
                    // if (collider.TryGetComponent(out Interactable01 Interactable01) && SupplyState01==1)
                    // {
                    //     SupplyState01=0;
                    //     Object001.GetComponent<MeshCollider>().enabled=true;
                    //     theSupply.GetComponent<Animation>().Play("Crate_Open");
                    //     redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count+10;
                    //     // Interactable01.Interact();
                    // }
                    // else if (collider.TryGetComponent(out Interactable02 Interactable02) && SupplyState02==1)
                    // {
                    //     SupplyState02=0;
                    //     Object002.GetComponent<MeshCollider>().enabled=true;
                    //     theSupply2.GetComponent<Animation>().Play("Crate_Open");
                    //     redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count+10;
                    //     // Interactable02.Interact();
                    // }
                    // ======================================================== 
                    if (collider.TryGetComponent(out Interactable01 Interactable01) && SupplyState01==1)
                    {
                        SupplyState01=0;
                        Interactable01.active();
                        redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count+10;
                        // Interactable01.Interact();
                    }        
                    else if (collider.TryGetComponent(out Interactable02 Interactable02) && SupplyState02==1)
                    {
                        SupplyState02=0;
                        Interactable02.active2();
                        redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count+10;
                        // Interactable01.Interact();
                    }        
                }
            }
        }
    }
}
