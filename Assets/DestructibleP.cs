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
	public GameObject killer;
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

    public void killbyR1()
    {
        photonView.RPC("killbyR",RpcTarget.All);
		photonView.RPC("Destroy2",RpcTarget.All);
	}
    public void killbyR2()
    {
        photonView.RPC("killbyR",RpcTarget.All);
		photonView.RPC("selfDestroy2",RpcTarget.All); 
	}

	[PunRPC]
    public void killbyR()
    {
        Rigidbody rb = Instantiate(killbyRin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }

    public void killbyY1()
    {
        photonView.RPC("killbyY",RpcTarget.All);
		photonView.RPC("Destroy2",RpcTarget.All);
	}
    public void killbyY2()
    {
        photonView.RPC("killbyY",RpcTarget.All);
		photonView.RPC("selfDestroy2",RpcTarget.All); 
	}

	[PunRPC]
    public void killbyY()
    {
        Rigidbody rb = Instantiate(killbyYin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }

    public void killbyG1()
    {
        photonView.RPC("killbyG",RpcTarget.All); 
		photonView.RPC("Destroy2",RpcTarget.All);
    }
    public void killbyG2()
    {
        photonView.RPC("killbyG",RpcTarget.All); 
		photonView.RPC("selfDestroy2",RpcTarget.All); 
    }
	
	[PunRPC]
    public void killbyG()
    {
        Rigidbody rb = Instantiate(killbyGin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }

	// public void selfDestroy () // throw by camman
	// {
	// 	photonView.RPC("selfDestroy2",RpcTarget.All); 
	// }

	public void Destroy () // not throw by camman
	{
		photonView.RPC("Destroy2",RpcTarget.All); 
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
			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag("Player");
			Rigidbody rb = Instantiate(endGame, transform.position, transform.rotation).GetComponent<Rigidbody>();
			if(gos[0].name=="player1"||gos[1].name=="player1" )
			{
				if(user.name=="player1")
				{
					rb.name=user.name;
				}            
				else
				{
					rb.name="player2";
				} 
			}
			if(gos[0].name=="player2"||gos[1].name=="player2")
			{
				if(user.name=="player2")
				{
					rb.name=user.name;
				}            
				else
				{
					rb.name="player1";
				} 
			}
			Rigidbody rb2 = Instantiate(killer, transform.position, transform.rotation).GetComponent<Rigidbody>();
			rb2.name="player1";
		}
    }

    [PunRPC] 
    public void selfDestroy2() // not throw by camman
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
			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag("Player");
			Rigidbody rb = Instantiate(endGame, transform.position, transform.rotation).GetComponent<Rigidbody>();
			print(gos[0].name); // <- User(Clone)
			print(gos[1].name); // player2
			if(gos[0].name=="player2"||gos[1].name=="player2")
			{
				if(user.name=="player2")
				{
					rb.name=user.name;
				}            
				else
				{
					rb.name="player1";
				} 
			}
			if(gos[0].name=="player1"||gos[1].name=="player1" )
			{
				if(user.name=="player1")
				{
					rb.name=user.name;
				}            
				else
				{
					rb.name="player2";
				} 
			}
			Rigidbody rb2 = Instantiate(killer, transform.position, transform.rotation).GetComponent<Rigidbody>();
			rb2.name="player2";
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
			Destroy2();
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
