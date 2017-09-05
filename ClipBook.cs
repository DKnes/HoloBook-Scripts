using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClipBook : MonoBehaviour {
    public GameObject rightPage;
    public GameObject leftPage;
    public GameObject animatorPageFront;
    public GameObject animatorPageBack;
    //[Tooltip("Delay time after playing the animator clip")]
    //public float delaySeconds = 0.65f;

    private TextMesh rightText;
    private TextMesh leftText;
    private TextMesh frontText;
    private TextMesh backText;
    private Animator animCtrl;
    private AudioSource sound;
    static int counter = 0;
    private void Start()
    {
        animCtrl = GetComponent<Animator>();
        rightText = rightPage.GetComponent<TextMesh>();
        leftText = leftPage.GetComponent<TextMesh>();
        frontText = animatorPageFront.GetComponent<TextMesh>();
        backText = animatorPageBack.GetComponent<TextMesh>();
        sound = GetComponent<AudioSource>();
       
        leftText.text = BookContentManager.Instance.Page(0);
        rightText.text= BookContentManager.Instance.Page(1);
    }
    public void ClipToPrev()
    {
        if (BookContentManager.Instance.curPage >= 2)
        {
            animatorPageFront.SetActive(true);
            animatorPageBack.SetActive(true);
            leftPage.SetActive(false);
            frontText.text = leftText.text;
            backText.text = BookContentManager.Instance.RelativePage(-2);
            animCtrl.SetTrigger("Prev Page");
            sound.Play();
            StartCoroutine(ChangeToPrev());
        }
    }
    private IEnumerator ChangeToPrev()
    {
        yield return new WaitForSeconds(0.2f);
        leftText.text = BookContentManager.Instance.RelativePage(-1,WordWrap.HandyTextHandler.FlippingMode.unchangeCurPage);
        leftPage.SetActive(true);
        yield return new WaitForSeconds(animCtrl.GetCurrentAnimatorStateInfo(0).length-0.26f);
        Debug.Log("Page changed to previous ones");
        rightText.text = backText.text;
        animatorPageFront.SetActive(false);
        animatorPageBack.SetActive(false);
    }
    public void ClipToNext()
    {
        if (BookContentManager.Instance.curPage < BookContentManager.Instance.numOfPages-1)
        {
            animatorPageFront.SetActive(true);
            animatorPageBack.SetActive(true);
            backText.text = rightText.text;
            frontText.text = BookContentManager.Instance.RelativePage(1);
            rightPage.SetActive(false);
            animCtrl.SetTrigger("Next Page");
            sound.Play();
            StartCoroutine(ChangeToNext());
        }
    }
    IEnumerator ChangeToNext()
    {
        yield return new WaitForSeconds(0.2f);
        rightText.text = BookContentManager.Instance.RelativePage(1);
        rightPage.SetActive(true);
        yield return new WaitForSeconds(animCtrl.GetCurrentAnimatorStateInfo(0).length-0.23f);

        Debug.Log("Page changed to next ones");

        leftText.text = frontText.text;


        animatorPageFront.SetActive(false);
        animatorPageBack.SetActive(false);
        
    }
    
}
