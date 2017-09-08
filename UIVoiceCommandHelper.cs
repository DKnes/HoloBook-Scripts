using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class UIVoiceCommandHelper : MonoBehaviour,IFocusable {
    [Tooltip("Depending on the tag of this GameObject")]
    public GameObject thisButtonVoiceHint;
    private void Start()
    {
        
    }
    public void OnFocusEnter()
    {
        Debug.Log("On Focus enter " + name);
        thisButtonVoiceHint.SetActive(true);
        //thisButtonVoiceHint.GetComponent<VoiceHint>().ResetTooltip();
        thisButtonVoiceHint.GetComponent<VoiceHint>().userMessage.text = "Say: \"" + name + "\"";
    }

    public void OnFocusExit()
    {
        thisButtonVoiceHint.GetComponent<VoiceHint>().ResetTooltip();
        thisButtonVoiceHint.SetActive(false);
    }
}
