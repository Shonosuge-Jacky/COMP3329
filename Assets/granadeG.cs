using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class granadeG : MonoBehaviourPunCallbacks
{
    // public float delay = 3f;
    public float radius =  3f;
    public float explosionForce = 700f ;

    public GameObject explosionEffect0;
    public GameObject explosionEffect;
    public GameObject Grenade;
    Rigidbody rb;

    // float countdown;
    bool hasExploded = false;
    bool hasExploded2 = false;
    // Start is called before the first frame update
    // void Start()
    // {
    //     countdown = delay;
    // }


    private void OnCollisionEnter(Collision collision){
        rb = GetComponent<Rigidbody>();
        hasExploded=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasExploded==true && rb.velocity.x==0 && rb.velocity.y==0 && rb.velocity.z==0 && hasExploded2==false)
        {
            Explode();
            hasExploded2=true;
        }
    }

    // bug – explode effect retain
    // public void EffectRemove()
    // {
    //     Destroy(explosionEffect);
    // }

    void Explode()
    {
        // bug – explode effect retain
        // Invoke("EffectRemove",5);
        Instantiate(explosionEffect0, transform.position, transform.rotation);
        // Debug.Log("BOOM!");
        // Show effect
        Invoke("gas",5);
        // Get nearby ojects
        // Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        // foreach(Collider nearbyObject in collidersToDestroy)
        // {
        //     // Add force
        //     // Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
        //     // if(rb!=null)
        //     // {
        //     //     rb.AddExplosionForce(explosionForce, transform.position, radius);
        //     // }
        //     // Damage
        //     Destructible dest = nearbyObject.GetComponent<Destructible>();
        //     // print(nearbyObject);
        //     if(dest!=null)
        //     {
        //         // dest.Destroy();
        //     }
        // }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToMove)
        {
            
            // Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb!=null)    
            {
                // rb.AddExplosionForce(explosionForce, transform.position, radius);
                if(rb.ToString()=="Player (UnityEngine.Rigidbody)")
                {
                    DestructibleP destP = nearbyObject.GetComponent<DestructibleP>();
                    if(destP!=null)
                    {
                        // destP.Destroy();
                    }
                }
            }
        }   
    }

    public void gas()
    {
        // explosionEffect0.active=false;
        Vector3 newPosition1 = transform.position + new Vector3(1f, 1f, 0f);
        Vector3 newPosition2 = transform.position + new Vector3(-1f, -1f, 0f);
        Vector3 newPosition3 = transform.position + new Vector3(0f, -1f, 1f);
        Vector3 newPosition4 = transform.position + new Vector3(0f, 1f, -1f);
        Quaternion newRotation1 = transform.rotation * Quaternion.Euler(90f, 0f, 0f);
        Quaternion newRotation2 = transform.rotation * Quaternion.Euler(-90f, 0f, 0f);
        Quaternion newRotation3 = transform.rotation * Quaternion.Euler(180f, 0f, 0f);
        Quaternion newRotation4 = transform.rotation * Quaternion.Euler(-180f, 0f, 0f);
        Instantiate(explosionEffect, newPosition1, newRotation1);
        Instantiate(explosionEffect, newPosition2, newRotation2);
        Instantiate(explosionEffect, newPosition3, newRotation3);
        Instantiate(explosionEffect, newPosition4, newRotation4);
        Destroy(gameObject);
    }
}
