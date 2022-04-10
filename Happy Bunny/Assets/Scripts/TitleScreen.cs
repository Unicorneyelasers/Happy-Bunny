using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    [SerializeField] Light2D globalLight;
    [SerializeField] Light2D bunLight;
    private float duration = 1f;
    public void OnStartButton()
    {
       // Messenger.Broadcast(GameEvent.START);
        Debug.Log("Start pushed. In TitleScreen");
        StartCoroutine(Fadeinstart());
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
            SceneManager.LoadScene(1);
        }
    }
}
