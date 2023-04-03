using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactable01 : MonoBehaviourPunCallbacks
{
    public GameObject theSupply;
    public GameObject Object001;
    public GameObject effect001;
    public bool opened;
    private float effectCountdown; // For effect duration

    void Start()
    {
        opened = false;
        effectCountdown = 15f;
    }

    void Update()
    {
        effectCountdown -= Time.deltaTime;

        if (effectCountdown <= 0f && effect001.active == true) // Disable effect after 15 seconds
        {
            effect001.active = false;
        }
        // If crate is opened, fade out
        if (opened)
        {
            var objRenderer = Object001.GetComponentInChildren<MeshRenderer>();
            var supplyRenderer = theSupply.GetComponentInChildren<MeshRenderer>();
            float speed = 0.3f;
            Color modifiedColor = objRenderer.material.color;
            modifiedColor.a -= speed * Time.deltaTime;
            objRenderer.material.color = modifiedColor;
            supplyRenderer.material.color = modifiedColor;
            if (modifiedColor.a <= 0.0f) // When transparent, destroy object
            {
                Destroy(theSupply);
                Destroy(Object001);
                Destroy(effect001);
                Debug.Log("destroyed");
                opened = false;
            }
        }
    }

    public void active()
    {
        photonView.RPC("activerpc", RpcTarget.All);
    }

    [PunRPC]
    public void activerpc()
    {
        Object001.GetComponent<MeshCollider>().enabled = true;
        theSupply.GetComponent<Animation>().Play("Crate_Open");
        opened = true;
    }
}
