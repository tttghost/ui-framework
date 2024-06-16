using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

interface IPopup<T1>
{
    T1 SetData<T2>(T2 t2);
}

public class popup_Base<T1> : ui_Base, IPopup<T1> where T1 : class
{
    private Button btn_Close;

    protected override void CacheComponent()
    {
        base.CacheComponent();
        btn_Close = gameObject.Search<Button>(nameof(btn_Close));
        btn_Close?.onClick.AddListener(Close);
    }


    public virtual T1 SetData<T2>(T2 t2)
    {
        return this as T1;
    }

}
