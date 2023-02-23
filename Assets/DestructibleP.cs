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

	// If the player clicks on the object
	public void Destroy ()
	// void OnMouseDown ()
	{
		if (barriering==false)
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
		}
	}
	
	void Update()
	{
		if (transform.position.y<-3)
		{
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.useGravity = false;
			float customGravity = 0.5f;
			rb.AddForce(Vector3.down * customGravity, ForceMode.Acceleration);
			rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			dead=1;
			Destroy();
		}
		if (Input.GetKey("r") && barriered==false && gameended==0)
		{
			if (photonView.IsMine)
			{
				barriered=true;
				// barriering=true;
				Invoke("barrierend",5);
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
