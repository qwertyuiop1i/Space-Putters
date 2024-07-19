using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucking : MonoBehaviour
{
    public float pullForce = 10.0f;
    public float pullRadius = 5.0f;

    public ParticleSystem ps;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var pe = ps.emission;
        pe.rateOverTime = pullForce * 3;
        var pss = ps.shape;
        pss.radius = pullRadius*0.5f;
    }
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pullRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Ball"))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance <= pullRadius)
                {
                    Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 direction = (transform.position - collider.transform.position).normalized;

                        float force = pullForce/(0.1f+Mathf.Pow(distance,2));
                        rb.AddForce(direction * force);
                    }
                }
            }
        }
    }
}
