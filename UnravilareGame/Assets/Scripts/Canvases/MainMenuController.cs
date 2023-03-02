using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject OptionsPanel;

    SceneController sceneController;
    private void Awake()
    {
        sceneController = new SceneController();
    }
    private void Start()
    {
        OptionsPanel.SetActive(false);
    }

    public void OnPlayButtonClick()
    {
        sceneController.LoadGameScene();
    }
    public void OnOptionsButonClick()
    {
        OptionsPanel.SetActive(true);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
