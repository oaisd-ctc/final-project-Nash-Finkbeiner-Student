using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Interactions : MonoBehaviour
{
    Door door;
    Light newlight;
    Player player;
    void Start()
    {
        newlight = FindAnyObjectByType<Light>();
        player = FindAnyObjectByType<Player>();
        door = FindAnyObjectByType<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        float camerapostion = Camera.main.transform.rotation.y;
        if(camerapostion == -1 || camerapostion == 1)
        {
            newlight.OnInteract();
        }
        if (camerapostion == 0)
        {
            door.OnInteract();
        }
    }
}
