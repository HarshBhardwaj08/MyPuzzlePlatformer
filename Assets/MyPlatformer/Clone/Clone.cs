using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : Skill
{
    public GameObject playerPrefab;
    public GameObject player;
    public float cloneSpeed = 5f;
    float timer;
    private void Start()
    {
        player = GameObject.Find("Player1").gameObject;
    }
    public override  void  Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
                ClonePlayer();
                timer = 0;
        }
    }

    void ClonePlayer()
    {
       
        GameObject clone = Instantiate(playerPrefab, player.transform.position ,player.transform.rotation);
        if (player.GetComponent<SpriteRenderer>().flipX == true)
        {
            clone.GetComponent<SpriteRenderer>().flipX = true;
            clone.GetComponent<Rigidbody2D>().AddForce(Vector2.right * cloneSpeed);
        }
        else if (player.GetComponent<SpriteRenderer>().flipX == false)
        {
            clone.GetComponent<SpriteRenderer>().flipX = false;
            clone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * cloneSpeed);
        }

    }
}
