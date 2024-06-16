using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneA : MonoBehaviour
{
    private void Start()
    {
    }
    private void Update()
    {
        //Test_Toast();
        //Test_Popup();
        Test_Panel();
        //Test_Nav();
    }

    private void Test_Toast()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIManager.instance.GetToast<toast_Basic>().SetData("hello").Show().Forget();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIManager.instance.GetToast<toast_Image>().SetData("testimage").Auto().Forget();
        }
    }

    private void Test_Popup()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIManager.instance.GetPopup<popup_Basic>().SetData(new dto_popup_Basic("hi", "hello")).Open();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIManager.instance.GetPopup<popup_Basic>().SetData(new dto_popup_Basic("hi", "haha")).Open();
        }
    }

    private void Test_Panel()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var v = UIManager.instance.GetPanel<panel_Basic>();
            v.SetData("hello");
            //UIManager.instance.PushPanel<panel_Basic>().SetData(new dto_panel_Basic("hi","hello"));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIManager.instance.PushPanel<panel_Basic>();
            //UIManager.instance.PopPanel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UIManager.instance.PopPanel();
            //UIManager.instance.GetPanel<panel_Image>().SetData(new dto_panel_Image("cat","testimage")).Push();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //UIManager.instance.GetPanel<panel_Basic>().Swap();
        }
    }

    private void Test_Nav()
    {

    }
}
