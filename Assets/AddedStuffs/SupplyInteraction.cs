using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SupplyInteraction : MonoBehaviourPunCallbacks
{
    private int SupplyState01=1;
    private int SupplyState02=1;
    public grenadeNumber redcount;
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
                    if (collider.TryGetComponent(out Interactable01 Interactable01) && SupplyState01==1)
                    {
                        SupplyState01=0;
                        // Interactable01.active();
                        redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count+10;
                    }        
                    else if (collider.TryGetComponent(out Interactable02 Interactable02) && SupplyState02==1)
                    {
                        SupplyState02=0;
                        // Interactable02.active2();
                        redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count+10;
                    }        
                }
                
            }
        }
    }
}
