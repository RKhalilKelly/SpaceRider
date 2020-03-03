using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 1;
    public Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(-30, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * moveSpeed);
    }
}
