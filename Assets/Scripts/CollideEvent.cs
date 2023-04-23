using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollideEvent : MonoBehaviour
{
    public bool antiLooper;
    public bool secondAntiLooper;
    public bool inRange;
    public bool metroInRange;
    public UnityEvent interactionAction;
    public UnityEvent secondInteractionAction;
    public UnityEvent thirdInteractionAction;
    public AudioSource audiosource;
    public AudioClip audioclip;


    // Update is called once per frame
    /*void Update()
    {
        if (inRange)
        {
            if (antiLooper == false)
            {
                interactionAction.Invoke();
                secondInteractionAction.Invoke();
                thirdInteractionAction.Invoke();
                antiLooper = true;
            }
        }
    }*/

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tracker"))
        {
            inRange = true;
            Debug.Log("You're in range, ma friend");
            if (inRange)
            {
                if (!antiLooper)
                {
                    interactionAction.Invoke();
                    secondInteractionAction.Invoke();
                    thirdInteractionAction.Invoke();
                    antiLooper = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tracker"))
        {
            antiLooper = false;
            inRange = false;

        }
    }

    public void SelfActivator()
    {
        this.gameObject.SetActive(true);
    }

    public void SelfDeactivator()
    {
        this.gameObject.SetActive(false);
    }
}

