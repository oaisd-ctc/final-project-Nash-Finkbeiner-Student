using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 

public class Power : MonoBehaviour
{

    public static float charge = 100f;
    public int timebeforeloss;
    public Text powerDisplay;
    public Door door;
    public LevelController levelController;
    public float powerloss;
    public float doorloss;
    private void Start()
    {
        door = FindAnyObjectByType<Door>();
        levelController = FindAnyObjectByType<LevelController>();
        StartCoroutine(StartPowerLoss());
    }
    private void Update()
    {
        if (charge > 100f)
        {
            charge = 100f;
        }
        if (charge <= 0f)
        {
            levelController.ChangeTheSceneLose();
        }
        powerDisplay.text = "Power: " + Mathf.Ceil(charge).ToString() + "%";
    }
    IEnumerator StartPowerLoss()
    {
        charge -= powerloss;
        if(door.closed)
        {
            charge -= doorloss;
        }
        yield return new WaitForSecondsRealtime(timebeforeloss);
        StartCoroutine(StartPowerLoss());
    }

    public void AddPower()
    {
        charge += 0.01f;
    }

    public void LosePower(float amount)
    {
        charge -= amount;
    }
}
