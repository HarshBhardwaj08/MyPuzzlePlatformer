using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    public float cloneSpeed = 5f;

   public  void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            
                ClonePlayer();
            
        }
    }

    void ClonePlayer()
    {
       
        GameObject clone = Instantiate(playerPrefab, player.transform.position,Quaternion.identity);

    
        Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
        if(player.GetComponent<SpriteRenderer>().flipX == true)
        {
            cloneRb.velocity = transform.right * cloneSpeed;
        }
        else
            cloneRb.velocity = (transform.right *-1 * cloneSpeed);



       
    }
}
