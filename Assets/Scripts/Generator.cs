using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generator : MonoBehaviour
{
    public UnityEvent pressed = new UnityEvent();
    Power gen = new Power();
    Player player = new Player();

    public void OnInteract()
    {
        if (Input.GetKey(KeyCode.E))
        {
            pressed.Invoke();
        }
    }
}
