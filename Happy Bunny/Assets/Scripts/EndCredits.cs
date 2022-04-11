using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;


public class EndCredits : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Light2D globalLight;
    [SerializeField] Light2D bunLight;
    private float duration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            StartCoroutine(Fadeinstart());
        }
    }
    IEnumerator Fadeinstart()
    {
        float outTime = 0;
        while (outTime < 1)
        {
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, 0, outTime);
            //  tunnelLight.intensity = Mathf.Lerp(tunnelLight.intensity, 0, outTime);
            bunLight.intensity = Mathf.Lerp(bunLight.intensity, 0, outTime);
            yield return null;
            outTime += Time.deltaTime / duration;
            // print(outTime);
        }
        if (outTime >= 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
