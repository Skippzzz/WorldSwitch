using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
    public GameObject objectToFollow;

    void Update()
    {
        Vector3 position = this.transform.position;
        if (PlayerScript.isCollidingX == false && PlayerScript.isCollidingY == false)
        {
            position.y = objectToFollow.transform.position.y + 6.5f;
            position.x = objectToFollow.transform.position.x;
        }
        else if (PlayerScript.isCollidingX == true && PlayerScript.isCollidingY == false)
        {
            position.y = objectToFollow.transform.position.y + 6.5f;
        }
        else if (PlayerScript.isCollidingY == true && PlayerScript.isCollidingX == false)
        {
            position.x = objectToFollow.transform.position.x;
        }
        this.transform.position = position;
    }
}
