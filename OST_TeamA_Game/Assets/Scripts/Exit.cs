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

    //Exit�{�^���ŃQ�[���I��
    public void OnClickExitButton()
    {
        EndConfirmPanel.SetActive(true);
    }

    public void OnClickYesButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
        Application.Quit();//�Q�[���v���C�I��
#endif
    }

    public void OnClickNoButton()
    {
        EndConfirmPanel.SetActive(false);
    }
}
