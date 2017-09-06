using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class UIVoiceCommandHelper : MonoBehaviour,IFocusable {
    public void OnFocusEnter()
    {
        UIButtonVoiceHintManager.Instance.ShowVoiceHint(gameObject);
    }

    public void OnFocusExit()
    {
        UIButtonVoiceHintManager.Instance.QuitVoiceHint(gameObject);
    }
}
