using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour
{
    public float strength=1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector2 hitDirection = collision.contacts[0].normal;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(collision.gameObject.GetComponent<Rigidbody2D>().velocity, hitDirection)*strength;
        }
    }
}
