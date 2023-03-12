using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffectDestroy : MonoBehaviour
{
    IEnumerator CountToDestroy(){
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    public void EffectDestroy(){
        StartCoroutine("CountToDestroy");
    }

}
