using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;

    public bool isMoving;
    public bool isAiming;
    public Vector2 aimDirection;
    public float power;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
        isAiming = true;
        power = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            rb.velocity = Vector2.zero;
            isAiming = true;
        }
        if (Input.GetMouseButton(0) && !isMoving)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            aimDirection = (mousePos - (Vector2)transform.position).normalized;
            power = Vector2.Distance((Vector2) transform.position, mousePos);
        }
        if (Input.GetMouseButtonUp(0) && isAiming)
        {
            isMoving = true;
            isAiming = false;
            rb.velocity = aimDirection * -power * 5f;
        }
        isMoving = rb.velocity.magnitude > 0.1f;
        

    }
}
