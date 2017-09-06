using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class FocusTest : MonoBehaviour, IFocusable
{
    private MeshRenderer myRenderer;

    private void Start()
    {
        myRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    public void OnFocusEnter()
    {
        myRenderer.enabled = false;
    }
    public void OnFocusExit()
    {
       myRenderer.enabled = true;
    }
}
