using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VoiceHint : MonoBehaviour {
    [Tooltip("The message stating which voice command is available on this VoiceHint.")]
    public Text userMessage;
    public Color commandHeardColor = new Color(0.33f, 0.14f, 0.93f, 1.0f);

    private Color startingColor;
    

    void Start()
    {
        startingColor = userMessage.color;
    }
   
    public void VoiceCommandHeard()
    {
        userMessage.color = commandHeardColor;
    }

    public void ResetTooltip()
    {
        userMessage.color = startingColor;
    }
}
