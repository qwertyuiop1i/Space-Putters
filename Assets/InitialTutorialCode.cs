using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTutorialCode : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;

    public bool onTut;
    void Start()
    {
        onTut = true;
        transform.localPosition = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
