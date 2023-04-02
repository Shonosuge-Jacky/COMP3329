using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactable02 : MonoBehaviourPunCallbacks
{
    public GameObject theSupply2;
    public GameObject Object002;
    public GameObject effect002;
    private bool opened = false;

    void Update()
    {
        if (opened)
        {
            var objRenderer = Object002.GetComponentInChildren<MeshRenderer>();
            var supplyRenderer = theSupply2.GetComponentInChildren<MeshRenderer>();
            float speed = 0.3f;
            Color modifiedColor = objRenderer.material.color;
            modifiedColor.a -= speed * Time.deltaTime;
            objRenderer.material.color = modifiedColor;
            supplyRenderer.material.color = modifiedColor;
            // Debug.Log("new:" + modifiedColor);
            if (modifiedColor.a <= 0.0f)
            {
                effect002.active = false;
                Destroy(theSupply2);
                Destroy(Object002);
                Debug.Log("destroyed");
                opened = false;
            }
        }
    }

    public void active2()
    {
        photonView.RPC("active2rpc", RpcTarget.All);
    }

    [PunRPC]
    public void active2rpc()
    {
        Object002.GetComponent<MeshCollider>().enabled = true;
        theSupply2.GetComponent<Animation>().Play("Crate_Open");
        opened = true;
    }
}
