using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucking : MonoBehaviour
{
    public float pullForce = 10.0f;
    public float pullRadius = 5.0f;

    public ParticleSystem ps;

    public LineRenderer lr;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var pe = ps.emission;
        pe.rateOverTime = Mathf.Abs(pullForce * 3);
        var pss = ps.shape;
        pss.radius = pullRadius*0.5f;


        lr = GetComponent<LineRenderer>();

        int segments = 360;
        float angle = 0f;

        lr.positionCount = segments + 1;
        lr.useWorldSpace = false;

        for (int i = 0; i < segments + 1; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * pullRadius*0.5f;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * pullRadius*0.5f;

            lr.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }

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

                        float force = pullForce/(0.01f+Mathf.Pow(distance,2));
                        rb.AddForce(direction * force);
                    }
                }
            }
        }
    }
}
