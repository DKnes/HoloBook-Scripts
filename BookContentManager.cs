using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using HoloToolkit.Unity;
using WordWrap;
using System.IO;

public class BookContentManager : Singleton<BookContentManager> {
    private HandyTextHandler textHandler;
    public int charOneLine = 27;
    public int lineOnePage = 21;
    public int leftPageNum { get; private set; }
    public int rightPageNum { get; private set; }
    public int numOfPages
    {
        get { return textHandler.numOfPages; }
    }
    /// <summary>
    /// 保证curPage==rightPageNum
    /// </summary>
    public int curPage
    {
        get { return textHandler.curPage; }
    }



    private string bookContent;
    private void Start()
    {
       
        //SetNewContent(@"D:\UnityProject\HoloApp\HoloBook\content.txt");
        
    }
    public void SetNewContent()
    {
        //StreamReader reader = new StreamReader(filePath);
        //bookContent= reader.ReadToEnd();
        //reader.Close();
        bookContent = GetComponent<UnityEngine.UI.Text>().text;
        textHandler = new HandyTextHandler(bookContent, charOneLine, lineOnePage);
        leftPageNum = 0;
        rightPageNum = 1;
        //Debug.Log(textHandler.numOfPages);
    }
    /// <summary>
    /// 暂时禁用，除ClipBook中的Start()
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public string Page(int num)
    {
        return textHandler.Page(num);
    }
    public string RelativePage(int num, HandyTextHandler.FlippingMode mode = HandyTextHandler.FlippingMode.changeCurPage)
    {
        return textHandler.RelativePage(num, mode);
    }
    

}
