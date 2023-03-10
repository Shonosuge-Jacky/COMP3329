using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrenadeThrower : MonoBehaviourPunCallbacks
{
    public float throwForce = 20f;
    public float throwForceY = 10f;
    public GameObject grenadePrefab;
    public GameObject grenadePrefabG;
    public GameObject RemoteGrenade;
    public GameObject RemoteGrenade2;
    public GameObject RemoteGrenade3;
    public grenadeNumber redcount;
    public grenadeNumberY yellowcount; 
    public grenadeNumberY yellowcount2;
    public grenadeNumberY yellowcount3;
    public grenadeNumber greencount;   
    public Transform originTransform;
    public Transform originTransformf;
 	private bool barriered=false;
 	private bool barriering=false;
    private int currentGrenade=0;
    public GameObject setting1;
    public GameObject setting2;
    public GameObject setting3;
    public GameObject setting12;
    public GameObject setting22;
    public GameObject setting32;
    public GameObject setting13;
    public GameObject setting23;
    public GameObject setting33;

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
            else if(Input.GetMouseButtonDown(0) && yellowcount.GetComponent<grenadeNumberY>().count==" 1" && currentGrenade==1)
            {
                setting1.active=true;
                setting2.active=true;
                setting3.active=true;
                yellowcount.GetComponent<grenadeNumberY>().count=" R";
                photonView.RPC("ThrowGrenadeY",RpcTarget.All);
                // ThrowGrenade();
            }
            else if(Input.GetMouseButtonDown(0) && yellowcount2.GetComponent<grenadeNumberY>().count==" 1" && currentGrenade==2)
            {
                setting12.active=true;
                setting22.active=true;
                setting32.active=true;
                yellowcount2.GetComponent<grenadeNumberY>().count=" R";
                photonView.RPC("ThrowGrenadeY2",RpcTarget.All);
                // ThrowGrenade();
            }
            else if(Input.GetMouseButtonDown(0) && yellowcount3.GetComponent<grenadeNumberY>().count==" 1" && currentGrenade==3)
            {
                setting13.active=true;
                setting23.active=true;
                setting33.active=true;
                yellowcount3.GetComponent<grenadeNumberY>().count=" R";
                photonView.RPC("ThrowGrenadeY3",RpcTarget.All);
                // ThrowGrenade();
            }
            else if(Input.GetMouseButtonDown(0) && greencount.GetComponent<grenadeNumber>().count>0 && currentGrenade==4)
            {
                greencount.GetComponent<grenadeNumber>().count=greencount.GetComponent<grenadeNumber>().count-1;
                photonView.RPC("ThrowGrenadeG",RpcTarget.All);
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
    public void ThrowGrenadeG()
    {
        Rigidbody rb = Instantiate(grenadePrefabG, originTransform.position, originTransform.rotation).GetComponent<Rigidbody>(); 
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

    [PunRPC] 
    public void ThrowGrenadeY2()
    {
        RemoteGrenade2.active=true;
        Rigidbody rb = RemoteGrenade2.GetComponent<Rigidbody>(); 
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

    [PunRPC] 
    public void ThrowGrenadeY3()
    {
        RemoteGrenade3.active=true;
        Rigidbody rb = RemoteGrenade3.GetComponent<Rigidbody>(); 
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
