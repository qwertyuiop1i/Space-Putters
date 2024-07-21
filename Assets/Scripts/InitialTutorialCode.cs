using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTutorialCode : MonoBehaviour
{
    public SpriteRenderer sr;
    public Vector2 travel;
    public float speed = 2f;
    public float fadeDuration = 1f;

    private bool movingToTarget = true;
    private float fadeTimer = 0f;
   


    void Update()
    {

        if ((transform.parent.GetComponent<Rigidbody2D>().velocity).sqrMagnitude > 0)
        {
            Destroy(gameObject);
        }
        if (movingToTarget)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, travel, speed * Time.deltaTime);

            if (Vector2.Distance(transform.localPosition, travel) < 0.1f)
            {
                movingToTarget = false;
                fadeTimer = 0f;
            }
        }
        else
        {
            fadeTimer += Time.deltaTime;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration));

            if (fadeTimer >= fadeDuration)
            {
                transform.localPosition = Vector2.zero;
                sr.color = Color.white; // Reset color to full opacity
                movingToTarget = true;
                fadeTimer = 0f;
            }
        }
    }
}
