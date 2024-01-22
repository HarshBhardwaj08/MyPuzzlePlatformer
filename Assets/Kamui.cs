using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kamui : MonoBehaviour
{
    public GameObject player;
    public Text text;
    public List<Transform> projectiles = new List<Transform>();
    public Dictionary<string, List<Transform>> projectileHolders = new Dictionary<string, List<Transform>>();
    public Image image;
    int count;
    bool sameSpriteSelected;
    
    private void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0.0f)
        {
        
            if (sameSpriteSelected)
            {
                count += 2;
                sameSpriteSelected = false;
            }
            else
            {
                count++;
            }

            count = (count) % projectiles.Count;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0.0f)
        {
            count--;
            sameSpriteSelected = false;
        } else if (Input.GetKeyDown(KeyCode.K))
        {
            PrintTransformDictionary();
        }
        if(projectiles.Count <= 0)
        {
            image.sprite = null;
        }
        count = Mathf.Clamp(count, 0, projectiles.Count -1);
       
        image.sprite = projectiles[count].GetComponent<SpriteRenderer>().sprite;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ThrowProjectile(dir);
        }
      
    }

    private void ThrowProjectile(Vector2 dir)
    {
        if (projectiles.Count > 0)
        {
            int num = count;
            bool flipX = player.GetComponent<SpriteRenderer>().flipX;
           
            projectiles[num].gameObject.SetActive(true);
            projectiles[num].gameObject.GetComponent<SpriteRenderer>().flipX = flipX;
            projectiles[num].gameObject.transform.position = dir;

            float velocityX = flipX ? -20f : 20f;
            projectiles[num].GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, 0);

            projectiles.RemoveAt(num);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            string ProjectileName = collision.transform.name;
            if (!projectileHolders.ContainsKey(ProjectileName))
            {
         
                projectileHolders[ProjectileName]  = new List<Transform>();
            }
            projectileHolders[ProjectileName].Add(collision.transform);
            text.text = projectileHolders[ProjectileName].Count.ToString();
            if (projectileHolders.ContainsKey("Knife"))
            {
                text.text = projectileHolders["knife"].Count.ToString();
            }

            projectiles.Add(collision.transform);
             
            collision.gameObject.SetActive(false);
        }
    }

    private void updateUI(string name)
    {
       
    }
   

    private void PrintTransformDictionary()
    {
       
        foreach (var kvp in projectileHolders)
        {
            Debug.Log("Key: " + kvp.Key);
            foreach (Transform transform in kvp.Value)
            {
                
                Debug.Log("  Transform: " + transform.name);
            }
        }
    }
}
