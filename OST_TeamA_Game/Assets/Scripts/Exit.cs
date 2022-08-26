using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class Exit : MonoBehaviour
{
    public GameObject EndConfirmPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Exitボタンでゲーム終了
    public void OnClickExitButton()
    {
        EndConfirmPanel.SetActive(true);
    }

    public void OnClickYesButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
        Application.Quit();//ゲームプレイ終了
#endif
    }

    public void OnClickNoButton()
    {
        EndConfirmPanel.SetActive(false);
    }
}
