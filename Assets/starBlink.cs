
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class starBlink : MonoBehaviour
{
    // Start is called before the first frame update
    public Light2D starlight;
    void Start()
    {
        starlight = GetComponent<Light2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
