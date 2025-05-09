using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    Door door;
    Light light;
    public LevelController levelcontroller;
    public UnityEvent Starting = new UnityEvent();
    public UnityEvent MoveToDoor = new UnityEvent();
    public UnityEvent MoveToWindow = new UnityEvent();
    public UnityEvent MoveToVent = new UnityEvent();
    public UnityEvent MoveToVentEnd = new UnityEvent();
    private bool atwindow = true;
    private bool atdoor = false;
    private bool atventstart = false;
    private bool atventend = false;
    public int diffuclty;
    public int timebetweenmoves;
    void Start()
    {
        door = FindAnyObjectByType<Door>();
        light = FindAnyObjectByType<Light>();
        levelcontroller = FindAnyObjectByType<LevelController>();
        Starting.Invoke();
        StartCoroutine(EnemyMovement());
    }

    private void Update()
    {
        if(atventend)
        {
            if(light.lighted) 
            {
                MoveToWindow.Invoke();
                atventend = false;
                atwindow = true;
            }
        }
    }

    IEnumerator EnemyMovement()
    {
        int randomnum = (int)Random.Range(1f, 20f);
        if (randomnum <= diffuclty)
        {
            if (atwindow)
            {
                int randomnum2 = (int)Random.Range(1f, 101f);
                print(randomnum2);
                if (randomnum2 <= 50)
                {
                    MoveToDoor.Invoke();
                    atwindow = false;
                    atdoor = true;
                }
                else if (randomnum2 >= 51)
                {
                    MoveToVent.Invoke();
                    atwindow = false;
                    atventstart = true;
                }
            }
            else if (atdoor && door.closed)
            {
                MoveToWindow.Invoke();
                atdoor = false;
                atwindow = true;
            }
            else if(atdoor && !door.closed)
            {
                levelcontroller.ChangeTheSceneLose(); ;
            }
            else if (atventstart)
            {
                MoveToVentEnd.Invoke();
                atventend = true;
                atventstart = false;
            }
            else if (atventend)
            {
                if (!light.lighted)
                {
                    levelcontroller.ChangeTheSceneLose();
                }
            }
        }
        yield return new WaitForSeconds(timebetweenmoves);
        StartCoroutine(EnemyMovement());
    }
}
