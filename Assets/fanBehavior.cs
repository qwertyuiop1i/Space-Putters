using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanBehavior : MonoBehaviour
{
    public float forceStrength = 10f;
    public float radius = 5f;
   





    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb!=null)
        {
            rb.AddForce(transform.up*forceStrength*Time.deltaTime);
            //Debug.Log("ge");
        }
    }



}
