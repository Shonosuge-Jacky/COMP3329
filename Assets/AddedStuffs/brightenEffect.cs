using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;


public class brightenEffect : MonoBehaviourPunCallbacks
{
    public GameObject lightEffect;
    // Update is called once per frame
    void Update()
    {
       if (photonView.IsMine)
        {
            if (Input.GetKey("q"))
            {
                transform.GetComponent<RectTransform>().localPosition = new Vector3(-880f, -461.9f, 0);
            }
            if (Input.GetKey("1"))
            {
                transform.GetComponent<RectTransform>().localPosition = new Vector3(-780f, -461.9f, 0);
            }
            if (Input.GetKey("2"))
            {
                transform.GetComponent<RectTransform>().localPosition = new Vector3(-680f, -461.9f, 0);
            }
            if (Input.GetKey("3"))
            {
                transform.GetComponent<RectTransform>().localPosition = new Vector3(-580f, -461.9f, 0);
            }
            if (Input.GetKey("e"))
            {
                transform.GetComponent<RectTransform>().localPosition = new Vector3(-480f, -461.9f, 0);
            }
        }
    }
}
