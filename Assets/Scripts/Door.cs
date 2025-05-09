using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public UnityEvent doorclose = new UnityEvent();
    public GameObject target1;       // First destination
    public GameObject target2;       // Second destination
    public float moveSpeed = 2f;    // Speed of movement
    private Vector3 currentTarget;    // Stores the current target position
    private bool movingToTarget1 = true;   // Flag to track movement direction
    public bool closed = false;
    Power power;

    void Start()
    {
        // Set the initial target to target1
        currentTarget = target1.transform.position;
        power = FindAnyObjectByType<Power>();
    }
    private void Update()
    {

    }
    public void OnInteract()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            doorclose.Invoke();
        }
    }

    public void Move()
    {
        // Check if the object is at the current target
        if (transform.position == currentTarget);
        {
            // If so, switch the target
            movingToTarget1 = !movingToTarget1;
            currentTarget = movingToTarget1 ? target2.transform.position : target1.transform.position;
        }

        // Move the object towards the target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);
        if(transform.position == target2.transform.position)
        {
            closed = true;
        }
        else
        {
            closed = false;
        }
    }
}
