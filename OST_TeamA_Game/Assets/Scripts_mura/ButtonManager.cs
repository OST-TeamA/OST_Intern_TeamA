using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //[SerializeField]
    //GameObject Menupanel;
    public GameObject MenuPanel;
    //Startボタンクリックで探索シーンに遷移
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("kari_main");

    }
    //Menuボタンでメニュー画面（パネル）表示
    public void OnClickMenuButton()
    {
        MenuPanel.SetActive(true);
    }

    //MenupanelのBackボタンでパネル非表示
    public void OnClickBackButton()
    {
        MenuPanel.SetActive(false);
    }

    //Retryボタンでバトルシーンに遷移
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("kari_battle");
    }

    //Returnボタンでタイトルシーンに遷移
    public void OnClickReturnButton()
    {
        SceneManager.LoadScene("Title");
    }

}

