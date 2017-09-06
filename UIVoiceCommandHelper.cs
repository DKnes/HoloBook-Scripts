using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class UIVoiceCommandHelper : MonoBehaviour,IFocusable {
    public GameObject allButtonVoiceHint;
    public GameObject oneButtonVoiceHint;
    public void OnFocusEnter()
    {
        //UIButtonVoiceHintManager.Instance.ShowVoiceHint(gameObject.tag,gameObject.name);
        ShowVoiceHint(gameObject.tag, gameObject.name);
    }

    public void OnFocusExit()
    {
        //UIButtonVoiceHintManager.Instance.QuitVoiceHint(gameObject.tag);
        QuitVoiceHint(gameObject.tag);
    }

    public void ShowVoiceHint(string tag, string name)
    {

        if (tag == "AllUIButton")
        {
            allButtonVoiceHint.SetActive(true);
            allButtonVoiceHint.GetComponent<VoiceHint>().userMessage.text = "Say: \"" + name + "\"";

        }
        else if (tag == "OneUIButton")
        {
            oneButtonVoiceHint.SetActive(true);
            oneButtonVoiceHint.GetComponent<VoiceHint>().userMessage.text = "Say: \"" + name + "\"";

        }
    }
    public void QuitVoiceHint(string tag)
    {
        if (tag == "AllUIButton")
        {
            allButtonVoiceHint.GetComponent<VoiceHint>().ResetTooltip();
            allButtonVoiceHint.SetActive(false);
        }
        else if (tag == "OneUIButton")
        {
            oneButtonVoiceHint.GetComponent<VoiceHint>().ResetTooltip();
            oneButtonVoiceHint.SetActive(false);
        }

    }
}
