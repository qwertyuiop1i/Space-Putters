using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEditor : MonoBehaviour
{
    public GameObject selected;
    public SpriteRenderer previewSprite;
    public float size;
    public float strength;
    public float rot;

    private void Start()
    {
        previewSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float gridSize = 1f;
        float snappedX = Mathf.Round(mousePos.x / gridSize) * gridSize;
        float snappedY = Mathf.Round(mousePos.y / gridSize) * gridSize;


        transform.position = new Vector2(snappedX, snappedY);
        transform.rotation = Quaternion.Euler(0, 0, rot);
        previewSprite.sprite = selected.GetComponent<SpriteRenderer>().sprite;
        

  
        previewSprite.color = new Color(1f, 1f, 1f, strength);

        if (Input.GetMouseButtonDown(0))
        {
            if (selected && selected.name != "empty")
            {
                Debug.Log("Placed");
                Vector2 snappedPosition = new Vector3(snappedX, snappedY, 0f);
                Instantiate(selected, snappedPosition, Quaternion.identity);
            }
        }
    }

    public void select(GameObject selection = null)
    {
        if (selection)
        {
            selected = selection;
            previewSprite.sprite = selected.GetComponent<SpriteRenderer>().sprite; 
        }
    }
}
