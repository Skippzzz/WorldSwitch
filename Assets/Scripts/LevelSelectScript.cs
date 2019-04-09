using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelSelectScript : MonoBehaviour
{
    public int SceneToLoad;
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
