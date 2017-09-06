using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class UIVoiceCommandHelper : MonoBehaviour,IFocusable {
    [Tooltip("Depending on the tag of this GameObject")]
    public GameObject thisButtonVoiceHint;
    
    public void OnFocusEnter()
    {
        thisButtonVoiceHint.SetActive(true);
        thisButtonVoiceHint.GetComponent<VoiceHint>().userMessage.text = "Say: \"" + name + "\"";
    }

    public void OnFocusExit()
    {
        thisButtonVoiceHint.GetComponent<VoiceHint>().ResetTooltip();
        thisButtonVoiceHint.SetActive(false);
    }
}
