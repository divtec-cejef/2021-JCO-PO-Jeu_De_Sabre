using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour
{

    public GameObject menuUi;
    public GameObject loadingUi;
    public GameObject playerStuff;
    public Slider loadingBar;
    public TextMeshProUGUI progressText;
    
    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnLaunch()
    {
        StartCoroutine(loadLevel());
    }


    private IEnumerator loadLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Map");

        menuUi.SetActive(false);
        playerStuff.SetActive(false);
        loadingUi.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.value = progress;
            progressText.text = (int)(progress * 100f) + "%";
            
            yield return null;
        }
    }
    
    
}
