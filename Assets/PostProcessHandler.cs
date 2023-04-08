using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessHandler : MonoBehaviourPunCallbacks
{
    public PostProcessVolume volume;
    public GameObject LoseSign;
    [SerializeField] private ColorGrading colorGrading;
	[SerializeField] private DepthOfField dof;
    [SerializeField] private Vignette vignette;
    [SerializeField] private ChromaticAberration cha;
    public bool doDead = false;
    private int stage=0;
    // public GameObject EndSceneUI;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out colorGrading);
        volume.profile.TryGetSettings(out dof);
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out cha);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stage==0)
        {  
			doDead=false;
			dof.active = false;
			stage=1;
		}
        if(gosc.Length == 0 && stage==1)
        {  
			stage=0;
		}

        if(photonView.IsMine){
            if(doDead == true){
                StartCoroutine("BlurEffect");
                doDead = false;
                
            }

            if(LoseSign.activeSelf == true){
                StartCoroutine(BlackEffect());
            }
            else{
                colorGrading.active = false;
            }
        }
    }

    public void DoGetHitEffect(){
        StartCoroutine(GetHitEffect());
    }
    public void DoWaterEffect(){
        StartCoroutine(WaterEffect());
    }
    public void DoDashEffect(){
        StartCoroutine(DashEffect());
    }
    IEnumerator BlackEffect(){
        colorGrading.active = true;
        yield return null;
    }
    IEnumerator BlurEffect(){
        Debug.Log(dof.active);
        dof.active = true;
        Debug.Log(dof.active);
        while (dof.focusDistance > 0.2f){
            yield return new WaitForSeconds(0.06f);
            dof.focusDistance.value -= 0.2f;
        }
        Debug.Log("doEndScene");
        // EndSceneUI.SetActive(true);
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

    IEnumerator DashEffect(){
        Debug.Log("DASH");
        cha.active = true;
        yield return new WaitForSeconds(0.7f);
        cha.active = false;
    }
}
