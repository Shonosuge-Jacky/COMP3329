using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Granade : MonoBehaviourPunCallbacks
{
    // public float delay = 3f;
    public float radius =  5f;
    public float explosionForce = 700f ;

    public GameObject explosionEffect;

    // float countdown;
    bool hasExploded = false;
    // Start is called before the first frame update
    // void Start()
    // {
    //     countdown = delay;
    // }


    private void OnCollisionEnter(Collision collision){
        Explode();
        hasExploded=true;
    }

    // Update is called once per frame
    void Update()
    {
        // countdown -= Time.deltaTime;
        // Debug.Log(hasExploded);
        // Debug.Log(countdown);
        // if(countdown<=0f && hasExploded==false)
        // // if(countdown<=0f && !hasExploded)
        // {
        //     Explode();
        //     hasExploded=true;
        // }
        if(hasExploded==true)
        // if(countdown<=0f && !hasExploded)
        {
            Destroy(gameObject);            
        }
    }

    // bug – explode effect retain
    public void EffectRemove()
    {
        Destroy(explosionEffect);
    }

    void Explode()
    {
        // bug – explode effect retain
        Invoke("EffectRemove",5);
        // Debug.Log("BOOM!");
        // Show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        // Get nearby ojects
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToDestroy)
        {
            // Add force
            // Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            // if(rb!=null)
            // {
            //     rb.AddExplosionForce(explosionForce, transform.position, radius);
            // }
            // Damage
            Destructible dest = nearbyObject.GetComponent<Destructible>();
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
        Destroy(gameObject);
    }
}
