using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class popup_Basic : popup_Base<popup_Basic>
{
    private TMP_Text tmp_Title;
    private TMP_Text tmp_Summary;

    protected override void CacheComponent()
    {
        base.CacheComponent();
        tmp_Title = gameObject.Search<TMP_Text>(nameof(tmp_Title));
        tmp_Summary = gameObject.Search<TMP_Text>(nameof(tmp_Summary));
    }

    public override popup_Basic SetData<T2>(T2 t2) 
    {
        dto_popup_Basic dto_Popup_Basic = t2 as dto_popup_Basic;
        tmp_Title.text = dto_Popup_Basic.title;
        tmp_Summary.text = dto_Popup_Basic.summary;

        return base.SetData(t2);
    }

}
