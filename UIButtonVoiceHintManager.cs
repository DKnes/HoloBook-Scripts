using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class UIButtonVoiceHintManager :Singleton<UIButtonVoiceHintManager>{
    public GameObject allButtonVoiceHint;
    public GameObject oneButtonVoiceHint;
    public GameObject defaultDisableButton;

    private GameObject[] UIButtons;
	// Use this for initialization
	void Start () {
        defaultDisableButton.SetActive(true);
        UIButtons = GameObject.FindGameObjectsWithTag("AllUIButton");
        foreach (GameObject obj in UIButtons)
        {
            obj.AddComponent<UIVoiceCommandHelper>();
        }
        UIButtons = GameObject.FindGameObjectsWithTag("OneUIButton");
        foreach (GameObject obj in UIButtons)
        {
            obj.AddComponent<UIVoiceCommandHelper>();
        }
        defaultDisableButton.SetActive(false);
        
	}
	public void ShowVoiceHint(GameObject uiButton)
    {
        if(uiButton.tag=="AllUIButton")
        {
            allButtonVoiceHint.GetComponent<VoiceHint>().userMessage.text = "Say: \"" + uiButton.name + "\"";
            allButtonVoiceHint.SetActive(true);
        }
        else if(uiButton.tag=="OneUIButton")
        {
            oneButtonVoiceHint.GetComponent<VoiceHint>().userMessage.text= "Say: \"" + uiButton.name + "\"";
            oneButtonVoiceHint.SetActive(true);
        }
    }
    public void QuitVoiceHint(GameObject uiButton)
    {
        if (uiButton.tag == "AllUIButton")
        {
            allButtonVoiceHint.SetActive(false);
        }
        else if (uiButton.tag == "OneUIButton")
        {
            oneButtonVoiceHint.SetActive(false);
        }

    }
}
