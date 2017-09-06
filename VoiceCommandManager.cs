using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class VoiceCommandManager : MonoBehaviour,IFocusable {
    public GameObject voiceHintPrefab;
    private GameObject openVoiceHintPrefab;
    public void OnFocusEnter()
    {
        
    }

    public void OnFocusExit()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        openVoiceHintPrefab = Instantiate(voiceHintPrefab);
        openVoiceHintPrefab.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
