using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneB : MonoBehaviour
{
    private void Start()
    {
    }
    private void Update()
    {
        //Test_Toast();
        Test_Panel();
    }

    private void Test_Panel()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIManager.instance.GetPanel<panel_Basic>().SetData(new dto_panel_Basic("hello", "world")).Push();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIManager.instance.GetPanel<panel_Image>().SetData(new dto_panel_Image("cat", "testimage")).Push();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
        }
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
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UIManager.instance.GetNav<nav_Top>().Show();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UIManager.instance.GetNav<nav_Top>().Hide();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UIManager.instance.GetNav<nav_Guide>().Show();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            UIManager.instance.GetNav<nav_Guide>().Hide();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            UIManager.instance.GetPopup<popup_Basic>().SetData(new dto_popup_Basic("a", "b")).Open();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            UIManager.instance.GetPopup<popup_Basic>().Close();
        }
    }
}
