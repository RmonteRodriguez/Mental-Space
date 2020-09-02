using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    protected JoyButton joybutton;

    void Update()
    {
        joybutton = FindObjectOfType<JoyButton>();

        if (joybutton.pressed)
        {
            SceneManager.LoadScene(1);
        }
    }
}
