using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanBehavior : MonoBehaviour
{
    public float forceStrength = 10f;
    public float radius = 5f;
    public float angleTolerance = 15f;




    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 directionToTarget = collider.transform.position - transform.position;
                float angle = Vector2.Angle(transform.right, directionToTarget);
               // Debug.Log(angle);

                if (angle <= angleTolerance)
                {
                    rb.AddForce(transform.right * forceStrength * Time.fixedDeltaTime);
                }
            }
        }
    }
    

    

}
