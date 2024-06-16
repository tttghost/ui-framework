using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPanel
{
    panel_Base SetData<T2>(T2 t2);
}
public class panel_Base : ui_Base, IPanel
{
    public virtual panel_Base SetData<T2>(T2 t2)
    {
        return this;
    }
}