using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleHelp : MonoBehaviour
{
    public bool showHelp = false;
    public GameObject helpPanel;
    public void toggle()
    {
        showHelp = !showHelp;
        if (showHelp)
        {
            helpPanel.SetActive(true);
        }
        else
        {
            helpPanel.SetActive(false);
        }
    }
}
