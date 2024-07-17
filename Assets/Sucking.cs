using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucking : MonoBehaviour
{
    public float pullForce = 10.0f;
    public float pullRadius = 5.0f;

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pullRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Ball"))
            {
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = (transform.position - collider.transform.position).normalized;
                    float distance = Vector2.Distance(transform.position, collider.transform.position);
                    float force = pullForce * (pullRadius - distance) / pullRadius;
                    rb.AddForce(direction * force);
                }
            }
        }
    }
}
