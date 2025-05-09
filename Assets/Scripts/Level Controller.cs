using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public UnityEvent ChangeLose = new UnityEvent();
    public UnityEvent ChangeWin = new UnityEvent();
    public void ChangeTheSceneLose()
    {
        ChangeLose.Invoke();
    }
    public void ChangeTheSceneWin()
    {
        ChangeWin.Invoke();
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
