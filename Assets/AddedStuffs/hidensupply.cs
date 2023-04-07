using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class hidensupply : MonoBehaviourPunCallbacks
{
    private float spawnDelay; // Delay between spawns
    private int spawnCount; // Number of crates spawned
    private int spawnLimit;

    // Array of spawn coordinates
    private Vector3[] spawnPoints =
    {
        new Vector3 // 1st: at the crossroads near the bridge
        {
            x = -126.1f,
            y = -6.63f,
            z = 122f
        },
        new Vector3 // 2nd: left of bridge near barricades
        {
            x = -165.17f,
            y = -8.25f,
            z = 93.3f
        }
    };

    // Array of spawn rotations
    private Vector3[] spawnRotations =
    {
        new Vector3 // 1st
        {
            x = 0,
            y = 270,
            z = 0
        },
        new Vector3 // 2nd
        {
            x = 0,
            y = 200,
            z = 0
        }
    };

    void Start()
    {
        spawnDelay = 0f;
        spawnCount = 0;
        spawnLimit = 2;
    }

    void Update()
    {
        if (spawnCount != spawnLimit)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Player");
            if (PhotonNetwork.IsMasterClient && gos.Length == 2)
            {
                Debug.Log("Master client and 2 players");
            }
            if (PhotonNetwork.IsMasterClient && gos.Length == 2 && spawnCount < spawnLimit) // Only if master client: Spawn control
            {
                PhotonNetwork.Instantiate(
                    "supplyPrefab",
                    spawnPoints[spawnCount],
                    Quaternion.Euler(spawnRotations[spawnCount])//
                );
                Debug.Log("Spawned supply at " + spawnPoints[spawnCount]);
                spawnCount++;
            }
        }
    }

    // Keeping for reference on delaying spawns

    // public float effectdelay01a = 0.5f;
    // float effectcountdown01a;
    // bool effectdelay01atf = false;

    // public float effectdelay02a = 9.5f;
    // float effectcountdown02a;
    // bool effectdelay02atf = false;

    // public float delay01 = 1f;
    // float countdown01;
    // bool hasspawned01 = false;

    // public float delay02 = 10f;
    // float countdown02;
    // bool hasspawned02 = false;

    // public float effectdelay01b = 15f;
    // float effectcountdown;
    // bool closeeffect = false;

    // public float effectdelay02b = 20f;
    // float effectcountdown02b;
    // bool closeeffect02 = false;

    // private int playernumber=0;
    // public GameObject Supply01;
    // public GameObject Supply02;
    // public GameObject effect01;
    // public GameObject effect02;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     countdown01 = delay01;
    //     countdown02 = delay02;
    //     effectcountdown = effectdelay01b;
    //     effectcountdown02a = effectdelay02a;
    //     effectcountdown02b = effectdelay02b;
    // }
    // // Update is called once per frame
    // void Update()
    // {
    //     GameObject[] gos;
    //     gos = GameObject.FindGameObjectsWithTag("Player");
    //     if(gos.Length == 2)
    //     {
    //         playernumber=2;
    //     }

    //     // if(1==1)
    //     if(playernumber==2)
    //     {
    //         countdown01 -= Time.deltaTime;
    //         countdown02 -= Time.deltaTime;
    //         effectcountdown -= Time.deltaTime;
    //         effectcountdown02b -= Time.deltaTime;
    //         effectcountdown02a -= Time.deltaTime;
    //         if(effectcountdown01a<=0f && effectdelay01atf==false)
    //         // if(countdown<=0f && !hasExploded)
    //         {
    //             effect01.active = true;
    //             effectdelay01atf=true;
    //         }
    //         if(effectcountdown02a<=0f && effectdelay02atf==false)
    //         // if(countdown<=0f && !hasExploded)
    //         {
    //             effect02.active = true;
    //             effectdelay02atf=true;
    //         }
    //         if(countdown01<=0f && hasspawned01==false)
    //         // if(countdown<=0f && !hasExploded)
    //         {
    //             Supply01.active = true;
    //             hasspawned01=true;
    //         }
    //         if(countdown02<=0f && hasspawned02==false)
    //         // if(countdown<=0f && !hasExploded)
    //         {
    //             Supply02.active = true;
    //             hasspawned02=true;
    //         }
    //         if(effectcountdown<=0f && closeeffect==false)
    //         // if(countdown<=0f && !hasExploded)
    //         {
    //             effect01.active = false;
    //             closeeffect=true;
    //         }
    //         if(effectcountdown02b<=0f && closeeffect02==false)
    //         // if(countdown<=0f && !hasExploded)
    //         {
    //             effect02.active = false;
    //             closeeffect02=true;
    //         }
    //     }
    // }
}
