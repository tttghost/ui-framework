using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class panel_Basic : panel_Base
{
    private TMP_Text tmp_Title;
    private TMP_Text tmp_Content;
    protected override void CacheComponent()
    {
        base.CacheComponent();
        tmp_Title = gameObject.Search<TMP_Text>(nameof(tmp_Title));
        tmp_Content = gameObject.Search<TMP_Text>(nameof(tmp_Content));
    }

    /// <summary>
    /// dto_panel_Basic
    /// </summary>
    /// <typeparam name="T2"></typeparam>
    /// <param name="t2"></param>
    /// <returns></returns>
    public override panel_Base SetData<T2>(T2 t2)
    {
        dto_panel_Basic dto_panel_Basic = t2 as dto_panel_Basic;
        tmp_Title.text = dto_panel_Basic.title;
        tmp_Content.text = dto_panel_Basic.content;

        return base.SetData(t2);
    }
}

public class dto_panel_Basic
{
    public string title;
    public string content;

    public dto_panel_Basic(string title, string content)
    {
        this.title = title;
        this.content = content;
    }
}
