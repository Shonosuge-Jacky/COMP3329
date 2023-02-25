using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeF : MonoBehaviour
{
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("close",5);
    }

    // Update is called once per frame

    public void close()
    {
        self.active=false;
    }
}
