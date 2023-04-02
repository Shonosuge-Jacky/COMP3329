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
    [SerializeField] private Vignette vignette;
    public bool doDead = false;
    public GameObject EndSceneUI;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out colorGrading);
        volume.profile.TryGetSettings(out dof);
        volume.profile.TryGetSettings(out vignette);
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

    public void DoGetHitEffect(){
        StartCoroutine(GetHitEffect());
    }
    public void DoWaterEffect(){
        StartCoroutine(WaterEffect());
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
        EndSceneUI.SetActive(true);
        yield return null;

	}

    IEnumerator GetHitEffect(){
        vignette.active = true;
        yield return new WaitForSeconds(0.7f);
        vignette.active = false;
    }

    IEnumerator WaterEffect(){
        colorGrading.active = true;
        colorGrading.colorFilter.overrideState = true;
        colorGrading.saturation.overrideState = true;
        yield return null;
    }
}
