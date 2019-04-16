/// <summary>
/// Must be placed on the camera
/// Have the parent for the real world object inside the real world
/// and fake in fake.
/// Each world must be one object
/// </summary>
using UnityEngine;
using System.Collections;

public class ScriptForWorldSwitch : MonoBehaviour
{
    //This should contain the parent object which includes all objects 
    //for the "real" world
    public GameObject RealWorld;

    //This should contain the parent object which includes all objects 
    //for the "fake" world
    public GameObject FakeWorld;

    //SoundTest part
    public AudioClip worldChange;
    //--------------

    // Checks wheter you are in the "real" world or not
    bool isReal;

    //Start() is only run once at start up
    void Start()
    {
        //You start in the "real" world
        isReal = true;
    }

    //Update() runs at all times for each frame
    void Update()
    {
        //Check if you puss the button R
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Checks if you are in the "real" world  
            if (isReal == true) {
                //Hide the "real" world
                RealWorld.SetActive(false);
                //Unhides the "fake" world
                FakeWorld.SetActive(true);
                //sets boolean to show "fake" world
                isReal = false;
                //SoundTest part
                SoundManager.instance.PlaySingle(worldChange);
                //--------------
            }
            //if you are not in the "real" world 
            //But presses R
            else
            {
                //Unhides the "real" world
                RealWorld.SetActive(true);
                //Hides the fake world
                FakeWorld.SetActive(false);
                //Sets boolean to show "fake" world
                isReal = true;
                //SoundTest part
                SoundManager.instance.PlaySingle(worldChange);
                //--------------
            }
        }
        
    }
}

