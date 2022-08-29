using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //[SerializeField]
    //GameObject Menupanel;
    public GameObject MenuPanel;
    //Start�{�^���N���b�N�ŒT���V�[���ɑJ��
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("kari_main");

    }
    //Menu�{�^���Ń��j���[��ʁi�p�l���j�\��
    public void OnClickMenuButton()
    {
        MenuPanel.SetActive(true);
    }

    //Menupanel��Back�{�^���Ńp�l����\��
    public void OnClickBackButton()
    {
        MenuPanel.SetActive(false);
    }

    //Retry�{�^���Ńo�g���V�[���ɑJ��
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("kari_battle");
    }

    //Return�{�^���Ń^�C�g���V�[���ɑJ��
    public void OnClickReturnButton()
    {
        SceneManager.LoadScene("Title");
    }

}

