using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text timertext;
    public int suriveuntil;
    public LevelController levelcontroller;
    

    // Update is called once per frame
    void Start()
    {
        levelcontroller = FindAnyObjectByType<LevelController>();
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        timertext.text = "Survive: " + suriveuntil.ToString();
        suriveuntil -= 1;
        if(suriveuntil <= 0)
        {
            levelcontroller.LoadScene("Game Over - Win");
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(StartTimer());
    }
}
