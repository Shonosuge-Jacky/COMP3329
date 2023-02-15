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

	// If the player clicks on the object
	public void Destroy ()
	// void OnMouseDown ()
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
	
	void Update()
	{
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("endGame");  
        if(gos2.Length >= 1)
        {
			// Stop Player Movement 
			PlayerMovementx.GetComponent<PlayerMovement>().enabled = false;
			// Stop Grenade Thrower
			GrenadeThrowerx.GetComponent<GrenadeThrower>().enabled = false;
			// Stop SupplyInteraction
			SupplyInteractionx.GetComponent<SupplyInteraction>().enabled = false;
        }   
	}
}
