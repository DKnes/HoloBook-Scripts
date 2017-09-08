using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Examples.InteractiveElements;
using HoloToolkit.Unity;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour {
    public GameObject allButton;
    public GameObject oneButton;
    public GameObject bookBillboard;

   
    private RectTransform allTr;
    private RectTransform oneTr;
    private Vector3 initPosition;
    private GameObject rotateButton;
    private GameObject moveButton;
    private GameObject tagalongButton;
    Vector3 velocity = Vector3.zero;

    private bool voiceHintOn = true;
    private List<UIVoiceCommandHelper> commandHelpers=new List<UIVoiceCommandHelper>();
    private void Start()
    {
       
        allTr = allButton.GetComponent<RectTransform>();
        initPosition = allTr.localPosition;
        oneTr = oneButton.GetComponent<RectTransform>();
        rotateButton = GameObject.Find("Rotate Book");
        moveButton = GameObject.Find("Move Book");
        tagalongButton = GameObject.Find("Book Tagalong");
        commandHelpers.AddRange(allButton.GetComponentsInChildren<UIVoiceCommandHelper>());
        commandHelpers.AddRange(oneButton.GetComponentsInChildren<UIVoiceCommandHelper>());
    }
    public void HideUIButton()
    {
        Vector3 targetPosition = new Vector3(-5000, 0, 0.046f);
        allButton.SetActive(false);
        oneButton.SetActive(true);
        //StartCoroutine(HideAnimation(targetPosition));
        Debug.Log("Hide UI button");
    }
    public void ShowUIButton()
    {
        Vector3 targetPosition = initPosition;
        allButton.SetActive(true);
        oneButton.SetActive(false);
        //StartCoroutine(ShowAnimation(targetPosition));
        Debug.Log("Show UI button");
    }
    public void RotateControl()
    {
        if (GestureManager.Instance.ActiveRecognizer != GestureManager.Instance.NavigationRecognizer)
        {
            EndManipulate();
            StartRotate();
        }
        else
        {
            EndRotate();
        }   
    }
    public void TagalongControl()
    {
        if(bookBillboard.GetComponent<Billboard>().isActiveAndEnabled)
        {
            tagalongButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            tagalongButton.GetComponent<Image>().color = Color.blue;
        }
        bookBillboard.GetComponent<Billboard>().enabled = !bookBillboard.GetComponent<Billboard>().enabled;
        bookBillboard.GetComponent<SimpleTagalong>().enabled = !bookBillboard.GetComponent<SimpleTagalong>().enabled;
    }

    public void ManipulateControl()
    {
        if(GestureManager.Instance.ActiveRecognizer!=GestureManager.Instance.ManipulationRecognizer)
        {
            EndRotate();
            StartManipulate();
        }
        else
        {
            EndManipulate();
        }
    }
    public void VoiceHintControl()
    {
        voiceHintOn = !voiceHintOn;
        
        foreach(var helper in commandHelpers)
        {
            helper.enabled=voiceHintOn;
        }
        if(!voiceHintOn)
        {
            GameObject.Find("AllButtonVoiceHint").SetActive(false);
            GameObject.Find("OneButtonVoiceHint").SetActive(false);
        }
    }
    //Hide/Show UI animations
    //These two IEnumerator functions have bugs when running on HoloLens
    IEnumerator HideAnimation(Vector3 targetPos)
    {
        int counter = 0;
        while (counter++ < 40)
        {

            allTr.localPosition = Vector3.SmoothDamp(allTr.localPosition, targetPos, ref velocity, 0.3f, Mathf.Infinity, 0.02f);
            yield return new WaitForSeconds(0.02f);
        }
        allButton.SetActive(false);
        oneButton.SetActive(true);
    }

    IEnumerator ShowAnimation(Vector3 targetPos)
    {
        allButton.SetActive(true);
        oneButton.SetActive(false);
        int counter = 0;
        while (counter++ < 40)
        {
            allTr.localPosition = Vector3.SmoothDamp(allTr.localPosition, targetPos, ref velocity, 0.3f, Mathf.Infinity, 0.02f);
            yield return new WaitForSeconds(0.02f);
        }

    }
    private void StartRotate()
    {
        GestureManager.Instance.Transition(GestureManager.Instance.NavigationRecognizer);
        //Change UI color
        rotateButton.GetComponent<Image>().color = Color.red;
        //Disable flipping the book
        GameObject.Find("Box008").GetComponent<GestureInteractive>().enabled = false;
        GameObject.Find("Box006").GetComponent<GestureInteractive>().enabled = false;

    }
    private void EndRotate()
    {
        GestureManager.Instance.Transition(GestureManager.Instance.TapRecognizer);
        //Change UI color
        rotateButton.GetComponent<Image>().color = Color.white;
        //Enable flipping the book
        GameObject.Find("Box008").GetComponent<GestureInteractive>().enabled = true;
        GameObject.Find("Box006").GetComponent<GestureInteractive>().enabled = true;
    }


    private void StartManipulate()
    {
        GestureManager.Instance.Transition(GestureManager.Instance.ManipulationRecognizer);
        //Change UI color
        moveButton.GetComponent<Image>().color = Color.red;
        //Disable flipping the book
        GameObject.Find("Box008").GetComponent<GestureInteractive>().enabled = false;
        GameObject.Find("Box006").GetComponent<GestureInteractive>().enabled = false;
    }
    private void EndManipulate()
    {
        GestureManager.Instance.Transition(GestureManager.Instance.TapRecognizer);
        //Change UI color
        moveButton.GetComponent<Image>().color = Color.white;
        //Enable flipping the book
        GameObject.Find("Box008").GetComponent<GestureInteractive>().enabled = true;
        GameObject.Find("Box006").GetComponent<GestureInteractive>().enabled = true;
    }
}
