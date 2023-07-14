using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public Vector2 dinoMoving = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dinoMoving.x = dinoMoving.y = 0;

        if (Input.GetKey("right"))
        {
            dinoMoving.x = 1;
        }else if (Input.GetKey("left"))
        {
            dinoMoving.x = -1;
        }
        if (Input.GetKey("up"))
        {
            dinoMoving.y = 1;
        }
        else if (Input.GetKey("down"))
        {
            dinoMoving.y = -1;
        }
    }
}
