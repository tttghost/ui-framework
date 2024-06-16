using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using Object = UnityEngine.Object;
using Unity.VisualScripting;

public class UIManager : Singleton<UIManager>
{

    #region base

    public Stack<ui_Base> stackPanel { get; set; } = new Stack<ui_Base>();
    public ui_Base[] ui_Bases { get;private set; }

    protected override void Awake()
    {
        base.Awake();
        CacheUI();
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += handlerSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= handlerSceneChanged;
    }

    /// <summary>
    /// 씬 이동 시 UI캐싱 다시
    /// </summary>
    /// <param name="arg0"></param>
    /// <param name="arg1"></param>
    private void handlerSceneChanged(Scene arg0, Scene arg1)
    {
        CacheUI();
    }

    /// <summary>
    /// UI 캐싱
    /// </summary>
    private void CacheUI()
    {
        ui_Bases = FindObjectsOfType<ui_Base>(true);
        ui_Bases.ToList().ForEach(x => x.gameObject.SetActive(true));
        ui_Bases.ToList().ForEach(x => x.gameObject.SetActive(false));
    }

    #endregion

    #region core

    #region nav

    /// <summary>
    /// 네비게이션 가져오기
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetNav<T>() where T : nav_Base<T>
    {
        nav_Base<T> nav_Base = default;
        for (int i = 0; i < ui_Bases.Length; i++)
        {
            nav_Base = ui_Bases[i] as T;
            if (nav_Base )
            {
                break;
            }
        }
        return nav_Base as T;
    }

    //public T ShowNav<T>(Action act = null) where T : nav_Base
    //{
    //    T nav_Base = GetNav<T>();
    //    nav_Base.Show(act);
    //    return nav_Base;
    //}

    //public T HideNav<T>(Action act = null) where T : nav_Base
    //{
    //    T nav_Base = GetNav<T>();
    //    nav_Base.Hide(act);
    //    return nav_Base;
    //}

    #endregion

    #region panel

    public T GetPanel<T>() where T : panel_Base<T>
    {
        panel_Base<T> panel_Base = default;

        for (int i = 0; i < ui_Bases.Length; i++)
        {
            panel_Base = ui_Bases[i] as T;
            if (panel_Base)
            {
                break;
            }
        }

        return panel_Base as T;
    }

    public T PushPanel<T>() where T : panel_Base<T>
    {
        return GetPanel<T>().Push();
    }

    public T SwapPanel<T>() where T : panel_Base<T>
    {
        return GetPanel<T>().Swap();
    }

    public ui_Base PopPanel()
    {
        if (stackPanel.Count > 0)
        {
            stackPanel.Pop().Close();
        }

        ui_Base ui_Base = default;
        if (stackPanel.Count > 0)
        {
            ui_Base = stackPanel.Peek();
            ui_Base.Open();
        }

        return ui_Base;
    }

    #endregion

    #region popup

    /// <summary>
    /// 팝업 가져오기
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetPopup<T>() where T : popup_Base<T>
    {
        popup_Base<T> popup_Base = default;
        for (int i = 0; i < ui_Bases.Length; i++)
        {
            popup_Base = ui_Bases[i] as T;
            if (popup_Base)
            {
                break;
            }
        }
        return popup_Base as T;
    }

    //public T OpenPopup<T>() where T : popup_Base
    //{
    //    T popup_Base = GetPopup<T>();
    //    popup_Base.Open();
    //    return popup_Base;
    //}

    //public popup_Base ClosePopup<T>() where T : popup_Base
    //{
    //    popup_Base popup_Base = default;
    //    for (int i = 0; i < popup_Bases.Length; i++)
    //    {
    //        popup_Base = popup_Bases[i];
    //        if (popup_Base as T)
    //        {
    //            break;
    //        }
    //    }
    //    popup_Base.Close();
    //    return popup_Base;
    //}

    #endregion

    #region toast

    /// <summary>
    /// 토스트 가져오기
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetToast<T>() where T: toast_Base<T>
    {
        toast_Base<T> toast_Base = default;
        for (int i = 0; i < ui_Bases.Length; i++)
        {
            toast_Base = ui_Bases[i] as T;
            if (toast_Base)
            {
                break;
            }
        }
        return toast_Base as T;
    }

    //public async UniTask<T> AutoToast<T>(float duration = 1f, Action show_before = null, Action show_after = null, Action hide_before = null, Action hide_after = null) where T : toast_Base
    //{
    //    T t = GetToast<T>();
    //    await t.Auto(duration, show_before, show_after, hide_before, hide_after);
    //    return t;
    //}

    //public async UniTask<T> ShowToast<T>(Action show_before = null, Action show_after = null) where T : toast_Base
    //{
    //    T t = GetToast<T>();
    //    await t.Show(show_before, show_after);
    //    return t;
    //}

    //public async UniTask<T> HideToast<T>(Action hide_before = null, Action hide_after = null) where T : toast_Base
    //{
    //    T t = GetToast<T>();
    //    await t.Hide(hide_before, hide_after);
    //    return t;
    //}

    //CancellationTokenSource cts_toast;
    //CancellationTokenSource cts_panel;
    //CancellationTokenSource cts_popup;
    //CancellationTokenSource cts_nav;

    //public CancellationTokenSource CancelToken(eCancellationToken eCancellationToken)
    //{
    //    CancellationTokenSource cts = default;

    //    switch (eCancellationToken)
    //    {
    //        case eCancellationToken.cts_toast: cts = cts_toast; break;
    //        case eCancellationToken.cts_panel: cts = cts_panel; break;
    //        case eCancellationToken.cts_popup: cts = cts_popup; break;
    //        case eCancellationToken.cts_nav: cts = cts_nav; break;
    //    }

    //    if (cts != null)
    //    {
    //        cts.Cancel();
    //        cts.Dispose();
    //    }

    //    cts = new CancellationTokenSource();


    //    switch (eCancellationToken)
    //    {
    //        case eCancellationToken.cts_toast: cts_toast = cts; break;
    //        case eCancellationToken.cts_panel: cts_panel = cts; break;
    //        case eCancellationToken.cts_popup: cts_popup = cts; break;
    //        case eCancellationToken.cts_nav: cts_nav = cts; break;
    //    }
    //    return cts;
    //}


    #endregion

    #endregion

}
