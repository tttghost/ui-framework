using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class toast_Basic : toast_Base<toast_Basic>
{
    private TMP_Text tmp_Content;

    protected override void CacheComponent()
    {
        base.CacheComponent();
        tmp_Content = gameObject.Search<TMP_Text>(nameof(tmp_Content));
    }

    public override toast_Basic SetData<T2>(T2 t2)
    {
        tmp_Content.text = t2 as string;
        return base.SetData(t2);
    }
}
