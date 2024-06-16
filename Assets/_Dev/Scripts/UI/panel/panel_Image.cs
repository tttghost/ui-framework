using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class panel_Image : panel_Base<panel_Image>
{
    private TMP_Text tmp_Title;
    private Image img_Content;
    protected override void CacheComponent()
    {
        base.CacheComponent();
        tmp_Title = gameObject.Search<TMP_Text>(nameof(tmp_Title));
        img_Content = gameObject.Search<Image>(nameof(img_Content));
    }

    /// <summary>
    /// dto_panel_Image
    /// </summary>
    /// <typeparam name="T2"></typeparam>
    /// <param name="t2"></param>
    /// <returns></returns>
    public override panel_Image SetData<T2>(T2 t2)
    {
        dto_panel_Image dto_panel_Image = t2 as dto_panel_Image;
        tmp_Title.text = dto_panel_Image.title;
        Sprite sprite = Resources.Load<Sprite>(dto_panel_Image.content);
        img_Content.sprite = sprite;
        return base.SetData(t2);
    }
}

public class dto_panel_Image
{
    public string title;
    public string content;

    public dto_panel_Image(string title, string content)
    {
        this.title = title;
        this.content = content;
    }
}
