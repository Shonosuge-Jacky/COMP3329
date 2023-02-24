using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrenadeY : MonoBehaviourPunCallbacks
{
    // public float delay = 3f;
    public float radius =  3f;
    public float explosionForce = 700f ;

    private int CanExplode=0;
    public GameObject explosionEffect;
    public grenadeNumberY yellowcount;
    public GameObject RemoteGrenade;
    public GameObject setting1;
    public GameObject setting2;
    public GameObject setting3;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject boxnum;
    private int throwed=0;

    // float countdown;
    bool hasExploded = false;

    private void OnCollisionEnter(Collision collision)
    {
        // setting1.active=true;
        // setting2.active=true;
        // setting3.active=true;
        Invoke("CanExplodef1",1);
        Invoke("CanExplodef2",2);
        Invoke("CanExplodef3",3);
    }

    private void CanExplodef1()
    {
        setting1.active=false;
    }
    private void CanExplodef2()
    {
        setting2.active=false;
    }
    private void CanExplodef3()
    {
        setting3.active=false;
        CanExplode=1; 
        box1.active=true;
        box2.active=true;
        box3.active=true;
        boxnum.active=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(throwed==0)
        {
            Invoke("CanExplodef1",13);
            Invoke("CanExplodef2",14);
            Invoke("CanExplodef3",15);
            throwed=1;
        }
        if (Input.GetKey("1") && CanExplode==1)
        {
            if(photonView.IsMine)
            {
                ExplodeY();
                hasExploded=true;
                yellowcount.GetComponent<grenadeNumberY>().count=" 0";
                CanExplode=0;
            }
        }
        // if(hasExploded==true)
        // {
        //     Destroy(gameObject);            
        // }
    }

    void ExplodeY()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        // Get nearby ojects
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToDestroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            // print(nearbyObject);
            if(dest!=null)
            {
                dest.Destroy();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToMove)
        {
            
            // Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb!=null)    
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
                if(rb.ToString()=="Player (UnityEngine.Rigidbody)")
                {
                    DestructibleP destP = nearbyObject.GetComponent<DestructibleP>();
                    if(destP!=null)
                    {
                        destP.Destroy();
                    }
                }
            }
        }
        
        // Remove grenade
        photonView.RPC("HideRG",RpcTarget.All);   
    }

    [PunRPC] 
    public void HideRG()
    {
        RemoteGrenade.active=false;
    }
}