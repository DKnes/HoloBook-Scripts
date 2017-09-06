using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class UIButtonVoiceHintManager :Singleton<UIButtonVoiceHintManager>{
    public GameObject allButtonVoiceHint;
    public GameObject oneButtonVoiceHint;
    public GameObject defaultDisableButton;

    //private GameObject[] UIButtons;
	// Use this for initialization
	void Start () {
        //defaultDisableButton.SetActive(true);
        //UIButtons = GameObject.FindGameObjectsWithTag("AllUIButton");
        //foreach (GameObject obj in UIButtons)
        //{
        //    UIVoiceCommandHelper temp=obj.AddComponent<UIVoiceCommandHelper>();
        //}
        //UIButtons = GameObject.FindGameObjectsWithTag("OneUIButton");
        //foreach (GameObject obj in UIButtons)
        //{
        //    obj.AddComponent<UIVoiceCommandHelper>();
        //}
        //defaultDisableButton.SetActive(false);
        
	}
	public void ShowVoiceHint(string tag,string name)
    {
        
        if(tag=="AllUIButton")
        {
            allButtonVoiceHint.SetActive(true);
            allButtonVoiceHint.GetComponent<VoiceHint>().userMessage.text = "Say: \"" + name + "\"";
            
        }
        else if(tag=="OneUIButton")
        {
            oneButtonVoiceHint.SetActive(true);
            oneButtonVoiceHint.GetComponent<VoiceHint>().userMessage.text= "Say: \"" + name + "\"";
            
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
