using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int currentLevel;
    SceneController sceneController = new SceneController();

    private void Awake()
    {
        sceneController.SaveGameScene(currentLevel);
    }
}
