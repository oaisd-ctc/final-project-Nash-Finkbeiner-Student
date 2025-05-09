using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2f;
    Generator obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = FindObjectOfType(typeof(Generator)) as Generator;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();

        if(Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            if (obj.tag == "Generator")
            {
                obj.OnInteract();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RotateCameraLeft();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateCameraRight();
        }
    }

    void RotateCameraLeft()
    {
        transform.Rotate(Vector3.up, 90);
    }
    void RotateCameraRight()
    {
        transform.Rotate(Vector3.up, -90);
    }
}
