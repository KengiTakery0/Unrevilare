using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    private readonly string GAME_LEVEL_INDEX = "LEVEL_INDEX";
    public int gamesceneIndex
    {
        private get
        {
            return PlayerPrefs.GetInt(GAME_LEVEL_INDEX, 1);
        }
        set
        {

        }
    }



    public void LoadGameScene()
    {
        SceneManager.LoadScene(gamesceneIndex);
    }





}