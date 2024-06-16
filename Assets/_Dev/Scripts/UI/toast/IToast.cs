using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

interface IToast<T1>
{
    /// <summary>
    /// 토스트 열기
    /// </summary>
    /// <param name="before"></param>
    /// <param name="after"></param>
    /// <returns></returns>
    UniTask<T1> Show(Action before = null, Action after = null);

    /// <summary>
    /// 토스트 닫기
    /// </summary>
    /// <param name="before"></param>
    /// <param name="after"></param>
    /// <returns></returns>
    UniTask<T1> Hide(Action before = null, Action after = null);

    /// <summary>
    /// 토스트 자동 열고 닫기
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="show_before"></param>
    /// <param name="show_after"></param>
    /// <param name="hide_before"></param>
    /// <param name="hide_after"></param>
    /// <returns></returns>
    UniTask<T1> Auto(float duration = 1f, Action show_before = null, Action show_after = null, Action hide_before = null, Action hide_after = null);


    T1 SetData<T2>(T2 t2) where T2 : class;
}
