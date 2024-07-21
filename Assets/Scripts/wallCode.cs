using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCode : MonoBehaviour
{
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 collisionNormal = collision.contacts[0].normal;


        var main = ps.velocityOverLifetime;

        main.x = collisionNormal.x;
        main.y = collisionNormal.y;
        

        // Play the particle system
        ps.Play();
    }
}
