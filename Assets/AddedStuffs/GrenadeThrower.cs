using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrenadeThrower : MonoBehaviourPunCallbacks
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public grenadeNumber redcount;
    public Transform originTransform;
    public Transform originTransformf;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if(Input.GetMouseButtonDown(0) && redcount.GetComponent<grenadeNumber>().count>0)
            {
                redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count-1;
                photonView.RPC("ThrowGrenade",RpcTarget.All);
                // ThrowGrenade();
            }
        }
    }

    [PunRPC] 
    public void ThrowGrenade()
    {
        Rigidbody rb = Instantiate(grenadePrefab, originTransform.position, originTransform.rotation).GetComponent<Rigidbody>(); 
        if (photonView.IsMine)
        {
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(originTransform.forward * throwForce, ForceMode.VelocityChange);
        }
    }

    // [PunRPC] 
    // public void ThrowGrenade()
    // {
    //     if (photonView.IsMine) // Missing -> throw grenade from all cam 
    //     {
    //         Rigidbody rb = Instantiate(grenadePrefab, transform.position, transform.rotation).GetComponent<Rigidbody>();
    //         rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    //     }    
    // }

    // Ignore Collisions (time)
    // private IEnumerator ChangeLayerToIgnoreCollisions(GameObject grenadePrefab)
    // {
    //     grenadePrefab.gameObject.layer=LayerMask.NameToLayer("IgnoreCollisions");
    //     yield return new WaitForSeconds(0.2f);
    //     grenadePrefab.gameObject.layer=LayerMask.NameToLayer("Default");
    // }

    // Ignore Collisions (first)
    // Collisions only active after first Collisions

    // public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    // {
    //     if (stream.IsWriting)
    //     {
    //         //this is the local client
    //         stream.SendNext(pitch);
    //     }
    //     else
    //     {
    //         //this is the clone
    //         pitch = (float)stream.ReceiveNext();
    //     }
    // }
}
