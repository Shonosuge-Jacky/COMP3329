using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class SupplyInteraction : MonoBehaviourPunCallbacks
{
    private int SupplyState01=1;
    private int SupplyState02=1;
    public grenadeNumber redcount;
    public grenadeNumber yellowcount;
	public GameObject s1;
	public GameObject s2;
    //==================================
    private void Update()
    {
        GameObject[] sfind;
        sfind = GameObject.FindGameObjectsWithTag("supply");  
        for (int i=0; i<sfind.Length; i++)
        {
            if(sfind[i].ToString()=="s1(Clone) (UnityEngine.GameObject)")
            {
                SupplyState01=0;
            }
            if(sfind[i].ToString()=="s2(Clone) (UnityEngine.GameObject)")
            {
                SupplyState02=0;
            }
        }

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
                        // SupplyState01=0;
                        photonView.RPC("borns1",RpcTarget.All);
                        Interactable01.active();
                        redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count+10;
                        if(yellowcount.GetComponent<grenadeNumberY>().count==" 0")
                        {
                            yellowcount.GetComponent<grenadeNumberY>().count=" 1";
                        }
                    }        
                    else if (collider.TryGetComponent(out Interactable02 Interactable02) && SupplyState02==1)
                    {
                        // SupplyState02=0;
                        photonView.RPC("borns2",RpcTarget.All);
                        Interactable02.active2();
                        redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count+10;
                        if(yellowcount.GetComponent<grenadeNumberY>().count==" 0")
                        {
                            yellowcount.GetComponent<grenadeNumberY>().count=" 1";
                        }
                    }        
                }
                
            }
        }
    }
    [PunRPC] 
    public void borns1()
    {
        Rigidbody rb1 = Instantiate(s1, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }
    [PunRPC] 
    public void borns2()
    {
        Rigidbody rb2 = Instantiate(s2, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }
}
