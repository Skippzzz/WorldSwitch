using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip triggerSound;
    AudioSource audio; 
   

    void Start()
    {
        audio = GetComponent <AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (triggerSound != null)
        {
            audio.PlayOneShot(triggerSound, 0.7F);
        }
    }
   
}
