using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Vector3[] rocketPos;
    public int currPosIndex = 1;

    public float moveSpeed = 7;

    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t = Time.deltaTime * moveSpeed;
        transform.position = Vector3.Lerp(transform.position, rocketPos[currPosIndex], t);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            currPosIndex = currPosIndex + 1;
            if(currPosIndex > rocketPos.Length - 1)
            {
                currPosIndex = rocketPos.Length - 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            currPosIndex = currPosIndex - 1;
            if(currPosIndex < 0)
            {
                currPosIndex = 0;
            }
        }
    }
}
