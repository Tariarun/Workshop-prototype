using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScreenManager : MonoBehaviour
{
    //Loading scene
    public void OnClick_Play()
    {
        GameplayManager.Instance.pause = false;
        SceneManager.LoadScene(1);
    }
    public void OnClick_Menu()
    {
        GameplayManager.Instance.pause = false;
        SceneManager.LoadScene(0);
    }
    public void OnClick_NextLevel2()
    {
        GameplayManager.Instance.pause = false;
        SceneManager.LoadScene(2);
    }
    public void OnClick_NextLevel3()
    {
        GameplayManager.Instance.pause = false;
        SceneManager.LoadScene(3);
    }

    //Other
    public void OnClick_Resume()
    {
        GameplayManager.Instance.pause = false;
        GameplayManager.Instance.uiPanels[2].SetActive(false);
        GameplayManager.Instance.uiPanels[0].SetActive(false);
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }
    
    public void OnClick_Test()
    {
        Debug.Log("I'm working");
    }
}
