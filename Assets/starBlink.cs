
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class starBlink : MonoBehaviour
{

    public Light2D starlight;
    public float blinkInterval = 1.0f; 
    public float lightOnDuration = 3.5f;

    private float timer = 0.0f;

    void Start()
    {
        starlight = GetComponent<Light2D>();
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer > blinkInterval)
        {
  
            timer = 0.0f;
            starlight.enabled = !starlight.enabled;
            StartCoroutine(BlinkLightCoroutine());
            //FIX THIS LATER
        }
    }


    IEnumerator BlinkLightCoroutine()
    {
         float targetIntensity = starlight.enabled ? 0.7f : 1.0f;
         float startIntensity = starlight.intensity;
         float elapsedTime = 0.0f;
    
         while (elapsedTime < lightOnDuration)
         {
             starlight.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / lightOnDuration);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
     }
}
