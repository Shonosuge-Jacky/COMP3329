using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrenadeY : MonoBehaviourPunCallbacks
{
    public float radius =  9f;
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
    private int stagec=0;
    private int dead=0;
    public DestructibleP DestructibleP;
    bool hasExploded = false;
    public GameObject setting1sound;
    public GameObject setting2sound;
    public GameObject setting3sound;
    public Transform originTransform;
    public Transform originTransformf;
// =============================================================================
    public void Awake()
    {
        hasExploded=false;
        CanExplode=0;
        throwed=0;
        box1.active=false;
        box2.active=false;
        box3.active=false;
        setting1sound.active=false;
        setting2sound.active=false;
        setting3sound.active=false;
        boxnum.active=false;
        dead=0;
    }
// =============================================================================
    private void OnCollisionEnter(Collision collision) //state0
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //#188
        if(throwed==0)
        {
            throwed=1;
            Invoke("CanExplodef1",1);
            Invoke("CanExplodef2",2);
            Invoke("CanExplodef3",3);
        }
    }
    private void ce3()
    { 
        if(throwed==0)
        {
            throwed=1;
            Invoke("CanExplodef1",1);
            Invoke("CanExplodef2",2);
            Invoke("CanExplodef3",3);
        }
    }
    private void CanExplodef1() //state1
    {
        setting1.active=false;
        setting1sound.active=true;
    }
    private void CanExplodef2() //state2
    {
        setting2.active=false;
        setting2sound.active=true;
    }
    private void CanExplodef3() //state3
    {
        setting3.active=false;
        setting3sound.active=true;
        CanExplode=1; 
        box1.active=true;
        box2.active=true;
        box3.active=true;
        boxnum.active=true;
    }
// =============================================================================
    public void upthrowed()
    {
        throwed=0;
    }
// =============================================================================
    void Update()
    {   
        // print(throwed);
        Invoke("des",12);
        // ================================================================
        if (Input.GetKey("1") && CanExplode==1 && dead==0) //state4
        {
            if(photonView.IsMine)
            {
                ExplodeY(); //state5
                hasExploded=true;
                yellowcount.GetComponent<grenadeNumberY>().count=" 0";
                CanExplode=0;
            }
        }

        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("endGame");  
        if(gos2.Length >= 1)
        {
            CancelInvoke("des");
            Invoke("des",2.9f);
            dead=1;
        }

        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stagec==0)
        {  
            hasExploded=false;
            yellowcount.GetComponent<grenadeNumberY>().count=" 1";
            CanExplode=0;
            throwed=0;
			stagec=1;
            box1.active=false;
            box2.active=false;
            box3.active=false;
            boxnum.active=false;
            dead=0;
            photonView.RPC("HideRG",RpcTarget.All);   
		}
        if(gosc.Length == 0 && stagec==1)
        {  
			stagec=0;
		}
    }

    void ExplodeY()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //#188
        photonView.RPC("explosionEf",RpcTarget.All);
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
                    if(destP!=null && gameObject.name=="player1") // not throw by camman
                    {
                        destP.killbyY1();
                    }
                    else if(destP!=null && gameObject.name=="player2") // throw by camman
                    {
                        destP.killbyY2();
                    }
                }
            }
        }
        photonView.RPC("HideRG",RpcTarget.All);   
    }

    [PunRPC] 
    public void HideRG()
    {
        RemoteGrenade.active=false;
    }
    [PunRPC] 
    public void explosionEf()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
    
    void des()
    {
        photonView.RPC("HideRG",RpcTarget.All); 
    }
}