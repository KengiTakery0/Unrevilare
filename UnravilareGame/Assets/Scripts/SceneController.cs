using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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

    IEnumerator LoadLevelAsync(float delay)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncLoad.allowSceneActivation = false;
       // _fadeOutImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
       // _backgroundMusic.StartFadeOut(delay);
        var timer = Time.time + delay;
        var timerDelay = timer - 1;
        while (!asyncLoad.isDone && (Time.time <= timer))
        {
          //  var color = _fadeOutImage.color;
            if (Time.time >= timerDelay)
            {
            //    color.a += Time.deltaTime;
           //     _fadeOutImage.color = color;
            }
          //  foreach (Background bg in _backgrounds)
          //  {
             //   bg.IncreaseSpeed();
          //  }
            yield return null;
        }
        asyncLoad.allowSceneActivation = true;
    }
    public void SaveGameScene(int Index)
    {
        PlayerPrefs.SetInt(GAME_LEVEL_INDEX, Index);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gamesceneIndex);
    }





}
