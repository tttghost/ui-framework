using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

/// <summary>
/// 
/// 토스트메세지 제네릭 클래스 입니다
/// 
/// 상단에 메세지를 띄울 수 있습니다.
/// 
/// </summary>
/// <typeparam name="T1"></typeparam>
public class toast_Base<T1> : ui_Base, IToast<T1> where T1 : class
{
    public bool isOpen { get; private set; }

    private CancellationTokenSource _cts;
    private CancellationTokenSource cts
    {
        get => _cts;
        set
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
            }
            _cts = value;
        }
    }


    protected override void CacheComponent()
    {
        base.CacheComponent();

        rectTransform.anchoredPosition = Vector3.zero;
        canvasGroup.alpha = 0f;
    }


    public virtual async UniTask<T1> Show(Action before = null, Action after = null)
    {
        isOpen = true;

        gameObject.SetActive(true);

        before?.Invoke();

        cts = new CancellationTokenSource();
        UniTask lerpPositionTask = Util.Lerp_RectTransform_AnchoredPosition(rectTransform, Vector3.zero, Vector3.up * -20f, token: cts.Token);
        UniTask lerpAlphaTask = Util.Lerp_CanvasGroup_Alpha(canvasGroup, 0f, 1f, token: cts.Token);
        await UniTask.WhenAll(lerpPositionTask, lerpAlphaTask);

        after?.Invoke();

        return this as T1;
    }

    public virtual async UniTask<T1> Hide(Action before = null, Action after = null)
    {
        if (!isOpen)
        {
            return default;
        }

        isOpen = false;

        before?.Invoke();

        cts = new CancellationTokenSource();
        UniTask lerpPositionTask = Util.Lerp_RectTransform_AnchoredPosition(rectTransform, Vector3.up * -20f, Vector3.zero, token: cts.Token);
        UniTask lerpAlphaTask = Util.Lerp_CanvasGroup_Alpha(canvasGroup, 1f, 0f, token: cts.Token);
        await UniTask.WhenAll(lerpPositionTask, lerpAlphaTask);

        after?.Invoke();

        gameObject.SetActive(false);

        return this as T1;
    }

    public virtual async UniTask<T1> Auto(float duration = 1, Action show_before = null, Action show_after = null, Action hide_before = null, Action hide_after = null)
    {
        await Show(show_before, show_after);

        cts = new CancellationTokenSource();
        await UniTask.WaitForSeconds(duration, cancellationToken: cts.Token);

        await Hide(hide_before, hide_after);

        return this as T1;
    }

    public virtual T1 SetData<T2>(T2 t2) where T2 : class
    {
        return this as T1;
    }
    
}
