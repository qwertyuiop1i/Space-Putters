using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEditor : MonoBehaviour
{
    public GameObject selected;
    //public GameObject[]

    public SpriteRenderer sr;
    public float size;
    public float strength;
    public float rot;


    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float gridSize = 1f;
        float snappedX = Mathf.Round(mousePos.x / gridSize) * gridSize;
        float snappedY = Mathf.Round(mousePos.y / gridSize) * gridSize;
        
        transform.position = new Vector2(snappedX,snappedY);
        if (Input.GetMouseButtonDown(0))
        {
            if (selected&&selected.name!= "empty")
            {
                
                Debug.Log("Placed");

                
                Vector2 snappedPosition = new Vector3(snappedX, snappedY,0f);
                
                Instantiate(selected, snappedPosition,Quaternion.identity);

            }
        }
    }
    public void select(GameObject selection=null)
    {
        if (selection)
        {
            selected = selection;

        }

    }
}
