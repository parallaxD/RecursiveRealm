using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    public void DisableRaycastCanvas()
    {
        canvas.GetComponent<GraphicRaycaster>().enabled = false;
    }
    public void EnableRaycastCanvas()
    {
        canvas.GetComponent<GraphicRaycaster>().enabled = true;
    }
        
}
