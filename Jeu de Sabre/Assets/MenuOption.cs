using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOption : MonoBehaviour
{
    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnLaunch()
    {
        SceneManager.LoadScene("Map");
    }
    
}
