using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEditor : MonoBehaviour
{
    public GameObject selected;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selected)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("Placed");

                float gridSize = 1f;
                float snappedX = Mathf.Round(mousePos.x / gridSize) * gridSize;
                float snappedY = Mathf.Round(mousePos.y / gridSize) * gridSize;
                Vector2 snappedPosition = new Vector3(snappedX, snappedY,0f);

                Instantiate(selected, snappedPosition,Quaternion.identity);

            }
        }
    }
    public void select(GameObject selection)
    {
        selected = selection;
    }
}
