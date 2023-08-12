using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject settingsMenue;

    private void Start()
    {
        settingsMenue.SetActive(false);
    }
    public void EnterSettings()
    {
        settingsMenue.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
