using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : MonoBehaviour
{
    public UnityEvent Leaving = new UnityEvent();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Leaving.Invoke();
        }
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
