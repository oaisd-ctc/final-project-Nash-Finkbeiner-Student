using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Events;

public class Light : MonoBehaviour
{
    public UnityEvent lightstart = new UnityEvent();
    public UnityEvent lightup = new UnityEvent();
    public UnityEvent lightdown = new UnityEvent();
    public bool lighted = false;
    Power gen = new Power();
    Player player = new Player();
    Power power;
    public float powerloss;
    public void OnInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lightup.Invoke();
            lighted = true;
        }
        if(Input.GetKeyUp(KeyCode.E)) 
        {
            lightdown.Invoke();
            power.LosePower(powerloss);
            lighted = false;
        }
    }

    public void Start()
    {
        power = FindAnyObjectByType<Power>();
        lightstart.Invoke();
    }
}
