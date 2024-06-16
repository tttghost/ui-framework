using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IPanel<T1>
{
    T1 Push();
    T1 Swap();
    T1 SetData<T2>(T2 t2);
}
public class panel_Base<T1> : ui_Base, IPanel<T1> where T1 : class
{
    public virtual T1 Push()
    {
        Stack<ui_Base> stackPanel = UIManager.instance.stackPanel;
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().Close();
        }
        stackPanel.Push(this);
        Open();

        return this as T1;
    }

    public virtual T1 Swap()
    {
        Stack<ui_Base> stackPanel = UIManager.instance.stackPanel;
        if (stackPanel.Count > 0)
        {
            stackPanel.Pop().Close();
        }
        stackPanel.Push(this);
        Open();
        return this as T1;
    }

    public virtual T1 SetData<T2>(T2 t2)
    {
        return this as T1;
    }
}
