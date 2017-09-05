using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class IndicatorCtrl : MonoBehaviour {
    public DirectionIndicator directionIndicator;
    public Image indicateImage;
	public void ChangeCondition()
    {
        directionIndicator.enabled = !directionIndicator.enabled;
        directionIndicator.DirectionIndicatorObject.SetActive(directionIndicator.enabled);
        if(directionIndicator.enabled)
        {
            indicateImage.color = Color.red;
        }
        else
        {
            indicateImage.color = Color.white;
        }
    }
	
}
