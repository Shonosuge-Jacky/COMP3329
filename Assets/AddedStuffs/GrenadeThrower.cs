using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrenadeThrower : MonoBehaviourPunCallbacks
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public GameObject RemoteGrenade;
    public grenadeNumber redcount;
    public grenadeNumberY yellowcount;    
    public Transform originTransform;
    public Transform originTransformf;
 	private bool barriered=false;
 	private bool barriering=false;
    private int currentGrenade=0;
    public GameObject setting1;
    public GameObject setting2;
    public GameObject setting3;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey("r") && barriered==false)
            {
				barriered=true;
				barriering=true;
                Invoke("barrierend",5);
            }
            if (Input.GetKey("q"))
            {
				currentGrenade=0;
            }
            if (Input.GetKey("1"))
            {
				currentGrenade=1;
            }
            if (Input.GetKey("2"))
            {
				currentGrenade=2;
            }
            if (Input.GetKey("3"))
            {
				currentGrenade=3;
            }
            if (Input.GetKey("e"))
            {
				currentGrenade=4;
            }
		}

        if (photonView.IsMine && barriering==false)
        {
            if(Input.GetMouseButtonDown(0) && redcount.GetComponent<grenadeNumber>().count>0 && currentGrenade==0)
            {
                redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count-1;
                photonView.RPC("ThrowGrenade",RpcTarget.All);
                // ThrowGrenade();
            }
            if(Input.GetMouseButtonDown(0) && yellowcount.GetComponent<grenadeNumberY>().count==" 1" && currentGrenade==1)
            {
                setting1.active=true;
                setting2.active=true;
                setting3.active=true;
                yellowcount.GetComponent<grenadeNumberY>().count=" R";
                photonView.RPC("ThrowGrenadeY",RpcTarget.All);
                // ThrowGrenade();
            }
        }
    }

	private void barrierend()
	{
        if (photonView.IsMine)
        {
			barriering=false;
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

    [PunRPC] 
    public void ThrowGrenadeY()
    {
        RemoteGrenade.active=true;
        Rigidbody rb = RemoteGrenade.GetComponent<Rigidbody>(); 
        rb.position= originTransform.position;
        rb.rotation= originTransform.rotation; 
        // RemoteGrenade.active=false;
        if (photonView.IsMine)
        {
            rb.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
        else
        {
            rb.GetComponent<Rigidbody>().AddForce(originTransform.forward * throwForce, ForceMode.VelocityChange);
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
