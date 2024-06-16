using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface INav<T1>
{
    void Show(Action act = null);
    void Hide(Action act = null);
    T1 SetData<T2>(T2 t2);
}
