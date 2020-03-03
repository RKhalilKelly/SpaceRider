using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rocket : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI points;

    public bool isAlive = true;
    public bool isFlinching = false;
    public int hp = 3;
    public int score = 0;
    public float flinchDur = 5;
    public float ft = 0;
    public SpriteRenderer s;
    public Color flinchColor = new Color(0.5f, 0, 0, 0);

    public Vector3[] rocketPos;
    public int currPosIndex = 1;
    public float t = 0;
    public float moveSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        health.text = "HP:" + hp;
        points.text = "Score: " + score;
    }

    void KillPlayer()
    {
        s.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Asteroid")
        {
            hp = hp - 1;
            isFlinching = true;
            if (hp < 0)
            {
                hp = 0;
                isAlive = false;
            }
            health.text = "HP: " + hp;
        }
        if (col.gameObject.name == "Points" && !isFlinching && isAlive)
        {
            score = score + 1;
            points.text = "Score: " + score;
        }
        if (!isAlive)
        {
            KillPlayer();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isFlinching && ft <= flinchDur)
        {
            ft += Time.deltaTime;
            s.color = Color.Lerp(Color.white, flinchColor, Mathf.PingPong(ft, 0.5f));
        }
        else if (ft > flinchDur)
        {
            ft = 0;
            isFlinching = false;
        }

        t = Time.deltaTime * moveSpeed;
        transform.position = Vector3.Lerp(transform.position, rocketPos[currPosIndex], t);

        if (Input.GetKeyDown(KeyCode.W))
        {
            currPosIndex = currPosIndex + 1;
            if (currPosIndex > rocketPos.Length - 1)
            {
                currPosIndex = rocketPos.Length - 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            currPosIndex = currPosIndex - 1;
            if (currPosIndex < 0)
            {
                currPosIndex = 0;

            }
        }
    }
}


