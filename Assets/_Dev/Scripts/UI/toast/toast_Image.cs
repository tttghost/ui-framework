using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toast_Image : toast_Base<toast_Image>
{
    private Image img_Content;

    protected override void CacheComponent()
    {
        base.CacheComponent();

        img_Content = gameObject.Search<Image>(nameof(img_Content));
    }
    public override toast_Image SetData<T2>(T2 t2)
    {
        Sprite sprite = Resources.Load<Sprite>(t2 as string);
        img_Content.sprite = sprite;

        return base.SetData(t2);
    }
}
