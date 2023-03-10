using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessHandler : MonoBehaviourPunCallbacks
{
    public PostProcessVolume volume;
    public DestructibleP desP;
    [SerializeField] private ColorGrading colorGrading;
	[SerializeField] private DepthOfField dof;
    public bool doDead = false;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out colorGrading);
        volume.profile.TryGetSettings(out dof);
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine){
            if(doDead == true){
                StartCoroutine("BlurEffect");
                doDead = false;
                if(desP.dead > 0){
                    StartCoroutine("BlackEffect");
                }
            }

        }
    }
    IEnumerator BlackEffect(){
        colorGrading.active = true;
        yield return null;
    }
    IEnumerator BlurEffect(){
            dof.active = true;
            while (dof.focusDistance > 0.2f){
                yield return new WaitForSeconds(0.1f);
                dof.focusDistance.value -= 0.2f;
            }
            yield return null;

	}
}
