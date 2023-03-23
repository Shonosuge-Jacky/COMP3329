using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DestructibleP : MonoBehaviourPunCallbacks
{

	public GameObject destroyedVersion;	// Reference to the shattered version of the object
	public GameObject PlayerMovementx;
	public GameObject GrenadeThrowerx;
	public GameObject SupplyInteractionx;
	public GameObject endGame;
	public GameObject killbyRin;
	public GameObject killbyYin;
	public GameObject killbyGin;
	public GameObject killbyOin;
 	private bool barriered=false;
 	private bool barriering=false;
    public GameObject barrierA;
    public GameObject barrierB;
    public GameObject barrierC;
    public GameObject Grey1;
    public GameObject Grey2;
    public GameObject Grey3;
    public GameObject barrierV;
	private int gameended=0;
	public int dead=0;
    public GameObject user;

    public void killbyR()
    {
        photonView.RPC("killbyR2",RpcTarget.All);
	}

	[PunRPC]
    public void killbyR2()
    {
        Rigidbody rb = Instantiate(killbyRin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }

    public void killbyY()
    {
        photonView.RPC("killbyY2",RpcTarget.All);
	}

	[PunRPC]
    public void killbyY2()
    {
        Rigidbody rb = Instantiate(killbyYin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }

    public void killbyG()
    {
        photonView.RPC("killbyG2",RpcTarget.All); 
    }
	
	[PunRPC]
    public void killbyG2()
    {
        Rigidbody rb = Instantiate(killbyGin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }

	public void selfDestroy () // throw by camman
	{
		photonView.RPC("selfDestroy2",RpcTarget.All); 
	}

	public void Destroy () // not throw by camman
	{
		photonView.RPC("Destroy2",RpcTarget.All); 
	}

    [PunRPC] 
    public void selfDestroy2() // throw by camman
    {
		if ((barriering==false && dead==0)||(barriering==true && dead==0 && transform.position.y<-3))
		{
			var rotationVector = transform.rotation.eulerAngles;
			rotationVector.x = 90;
			transform.rotation = Quaternion.Euler(rotationVector);
			// Stop Player Movement 
			PlayerMovementx.GetComponent<PlayerMovement>().enabled = false;
			// Stop Grenade Thrower
			GrenadeThrowerx.GetComponent<GrenadeThrower>().enabled = false;
			// Stop SupplyInteraction
			SupplyInteractionx.GetComponent<SupplyInteraction>().enabled = false;
			Rigidbody rb = Instantiate(endGame, transform.position, transform.rotation).GetComponent<Rigidbody>();
			if(user.name=="User(Clone)")
			{
                print("2.1");
				rb.name=user.name+"1";
				dead=1;
				// print(rb.name);
				// print(user.name+" is dead");
				// print("is killed by other");
			}
			else
			{
                print("2.2");
				rb.name=user.name+"2";
				dead=1;
				// print(rb.name);
				// print(user.name+" is dead");
				// print("is self kill");
			}
		}
    }

    [PunRPC] 
    public void Destroy2() // not throw by camman
    {
		if ((barriering==false && dead==0)||(barriering==true && dead==0 && transform.position.y<-3))
		{
			var rotationVector = transform.rotation.eulerAngles;
			rotationVector.x = 90;
			transform.rotation = Quaternion.Euler(rotationVector);
			// Stop Player Movement 
			PlayerMovementx.GetComponent<PlayerMovement>().enabled = false;
			// Stop Grenade Thrower
			GrenadeThrowerx.GetComponent<GrenadeThrower>().enabled = false;
			// Stop SupplyInteraction
			SupplyInteractionx.GetComponent<SupplyInteraction>().enabled = false;
			Rigidbody rb = Instantiate(endGame, transform.position, transform.rotation).GetComponent<Rigidbody>();
			if(user.name=="User(Clone)")
			{
                print("2.3");
				rb.name=user.name+"2";
				dead=1;
				// print(rb.name);
				// print(user.name+" is dead");
				// print("is self kill");
			}
			else
			{
                print("2.4");
				rb.name=user.name+"1";
				dead=1;
				// print(rb.name);
				// print(user.name+" is dead");
				// print("is killed by other");
			}
		}
    }

	void Update()
	{
		if (transform.position.y<-3 && dead==0)
		{
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.useGravity = false;
			float customGravity = 0.5f;
			rb.AddForce(Vector3.down * customGravity, ForceMode.Acceleration);
			rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			Destroy();
        	Rigidbody rb2 = Instantiate(killbyOin, transform.position, transform.rotation).GetComponent<Rigidbody>();
		}
		if (Input.GetKey("r") && barriered==false && gameended==0)
		{
			if (photonView.IsMine)
			{
				barriered=true;
				// barriering=true;
				Invoke("barrierend",10);
				barrierA.active = false;
				barrierB.active = true;
				Grey1.active = true;
				Grey2.active = true;
				Grey3.active = true;
				// barrierV.active = true;
				photonView.RPC("barrier",RpcTarget.All);
			}
		}

        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("endGame");  
        if(gos2.Length >= 1)
        {
			// print(gos2[0]); ** endGame(Clone) (UnityEngine.GameObject)
			gameended=1;
			// Stop Player Movement 
			PlayerMovementx.GetComponent<PlayerMovement>().enabled = false;
			// Stop Grenade Thrower
			GrenadeThrowerx.GetComponent<GrenadeThrower>().enabled = false;
			// Stop SupplyInteraction
			SupplyInteractionx.GetComponent<SupplyInteraction>().enabled = false;
        }   
	}
	
    [PunRPC] 
    public void barrier()
    {
		barriering=true;
		barrierV.active = true;
    }
	
	private void barrierend()
	{
        if (photonView.IsMine)
        {
			// barriering=false;
			barrierB.active = false;
			barrierC.active = true;
			Grey1.active = false;
			Grey2.active = false;
			Grey3.active = false;
			// barrierV.active = false;
			photonView.RPC("barrierend2",RpcTarget.All);
		}		
	}

    [PunRPC] 
    public void barrierend2()
    {
		barriering=false;
		barrierV.active = false;
    }
}
