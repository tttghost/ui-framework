using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class nav_Base<T1> : ui_Base, INav<T1> where T1 : class
{
    #region 사이드 애니메이션 연출 values
    private RectTransform rootRectTransform;
    private Vector2[] appear = new Vector2[]
    {
        new Vector2(0f, 0.5f),
        new Vector2(1f, 0.5f),
        new Vector2(0.5f, 1f),
        new Vector2(0.5f, 0f),
    };
    private Vector2[] disappear = new Vector2[]
    {
        new Vector2(1f, 0.5f),
        new Vector2(0f, 0.5f),
        new Vector2(0.5f, 0f),
        new Vector2(0.5f, 1f),
    };
    private Dictionary<eNavAnimation, Vector2> animationPivot_Appear = new Dictionary<eNavAnimation, Vector2>();
    private Dictionary<eNavAnimation, Vector2> animationPivot_DisAppear = new Dictionary<eNavAnimation, Vector2>();


    [SerializeField]
    private eNavAnimation _eNavAnimation = eNavAnimation.Left;

    public eNavAnimation eNavAnimation
    {
        get => _eNavAnimation;
        set
        {
            _eNavAnimation = value;
            SetAncorPivot();
        }
    }
    /// <summary>
    /// 앵커 포지션 셋팅
    /// </summary>
    private void SetAncorPivot()
    {
        int index = (int)eNavAnimation;
        rootRectTransform.anchorMin = appear[index];
        rootRectTransform.anchorMax = appear[index];
        rootRectTransform.pivot = appear[index];
    }

    public float pading = 10f;

    #endregion


    public override void Awake()
    {
        base.Awake();
        CacheAnimation();
    }

    /// <summary>
    /// 컴포넌트 캐싱
    /// </summary>
    protected override void CacheComponent()
    {
        base.CacheComponent();

        GameObject go_Root_Parent = new GameObject(nameof(go_Root_Parent));
        go_Root_Parent.transform.SetParent(transform, false);

        rootRectTransform = go_Root_Parent.GetOrAddComponent<RectTransform>();
        rootRectTransform.sizeDelta = rectTransform.sizeDelta;
        rootRectTransform.sizeDelta = new Vector2(rootRectTransform.sizeDelta.x + pading * 2f, rootRectTransform.sizeDelta.y + pading * 2f);

        rectTransform.SetParent(rootRectTransform, false);
    }

    /// <summary>
    /// 애니메이션 캐싱
    /// </summary>
    private void CacheAnimation()
    {
        for (int i = 0; i < Util.EnumLength<eNavAnimation>(); i++)
        {
            animationPivot_Appear.Add((eNavAnimation)i, appear[i]);
            animationPivot_DisAppear.Add((eNavAnimation)i, disappear[i]);
        }
        eNavAnimation = _eNavAnimation;
    }



    public virtual async void Show(Action act = null)
    {
        gameObject.transform.SetAsLastSibling();

        gameObject.SetActive(true);

        await Util.Lerp_RectTransform_Pivot(
            rootRectTransform, 
            animationPivot_DisAppear[eNavAnimation],
            animationPivot_Appear[eNavAnimation], 
            EasingFunction.Ease.EaseOutExpo);
        act?.Invoke();
    }

    public virtual async void Hide(Action act = null)
    {
        await Util.Lerp_RectTransform_Pivot(
            rootRectTransform, 
            animationPivot_Appear[eNavAnimation],
            animationPivot_DisAppear[eNavAnimation], 
            EasingFunction.Ease.EaseInExpo);
        act?.Invoke();

        gameObject.SetActive(false);
    }

    public virtual T1 SetData<T2>(T2 t2)
    {
        return this as T1;
    }

}
