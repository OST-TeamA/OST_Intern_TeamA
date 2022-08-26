using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResume : MonoBehaviour
{
    public void OnClick()
    {
        Time.timeScale = 1.0f;
        Destroy(transform.parent.gameObject);
    }

}
