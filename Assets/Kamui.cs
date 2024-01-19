using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kamui : MonoBehaviour
{
    public GameObject player;
    public List<Transform> projectles = new List<Transform>();
    public Image image;
    int count;
    private void Update()
    {
        
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0.0f)
        {
            count++;
            if(count >= projectles.Count )
            {
                count = 0;
            }
        }else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0.0f)
        {
            count--;
        }
        image.sprite = projectles[count].GetComponent<SpriteRenderer>().sprite;
        count = Mathf.Clamp(count, 0,projectles.Count);
        Debug.Log(count);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            int num = count;
            
                if(player.GetComponent<SpriteRenderer>().flipX == true)
                {
                    projectles[num].gameObject.SetActive(true);
                    projectles[num].gameObject.GetComponent<SpriteRenderer>().flipX = false;
                   
                    projectles[num].gameObject.transform.position = dir;
                    projectles[num].GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
                    projectles.RemoveAt(num);
                }
                else
                {
                    projectles[num].gameObject.SetActive(true);
                    projectles[num].gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    projectles[num].gameObject.transform.position = dir;
                    projectles[num].GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
                    projectles.RemoveAt(num);
                }
               
            

           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FireBall")
        {
            projectles.Add(collision.transform);
            collision.gameObject.SetActive(false);
        }
    }
}
