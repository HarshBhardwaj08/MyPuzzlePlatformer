using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kamui : MonoBehaviour
{
    public GameObject player;
    public Text Uitext;
    public List<Transform> projectiles = new List<Transform>();
    public List<string> projectileName = new List<string>();
    public Dictionary<string, List<Transform>> projectileHolders = new Dictionary<string, List<Transform>>();
    public Image image;
    public int count = 0;
    
   public enum Projectiles
    {
        Sword,
        FireBall,  
        Kunai,
    }

    private Projectiles CurrentprojectilesValue;
    private void Start()
    {
        CurrentprojectilesValue = Projectiles.Sword;
    }
    private void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");


        if (scrollInput > 0f)
        {

            IterateCount(true); 
           // IterateEnums(true);
        }
       
        /*if(projectiles.Count <= 0)
        {
            image.sprite = null;
        }*/

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Debug.Log(CurrentprojectilesValue);
            ThrowProjectile(projectileName[count] ,dir);
        }
      
    }
    private void IterateCount(bool forward)
    {
        int currentIndex = count;
        int enumLength = projectileName.Count;

        int nextIndex;

        if (forward)
        {
            nextIndex = (currentIndex + 1) % enumLength;
        }
        else
        {
            nextIndex = (currentIndex - 1 + enumLength) % enumLength;
        }
        count = nextIndex;
      
        UpdateUI(projectileName[count].ToString());

        
    }
    private void IterateEnums(bool forward)
    {
        int currentIndex = (int)CurrentprojectilesValue ;
        int enumLength = Enum.GetValues(typeof(Projectiles)).Length;

        int nextIndex;

        if (forward)
        {
            nextIndex = (currentIndex + 1) % enumLength;
        }
        else
        {
            nextIndex = (currentIndex - 1 + enumLength) % enumLength;
        }

        CurrentprojectilesValue = (Projectiles)nextIndex;
        UpdateUI(CurrentprojectilesValue.ToString());
        //Debug.Log("Current Enum Value: " + CurrentprojectilesValue);
    }

    private void ThrowProjectile(string name,Vector2 dir)
    {
       
        Debug.Log(name);
        if (projectileHolders.ContainsKey(name))
        {
           
            int val = projectileHolders[name].Count - 1;
            projectileHolders[name][val].gameObject.SetActive(true);
            projectileHolders[name][val].gameObject.transform.position = dir;
            projectileHolders[name][val].GetComponent<Rigidbody2D>().velocity = new Vector2(-20f, 0);
            projectileHolders[name].RemoveAt(val);
            
            UpdateUI(CurrentprojectilesValue.ToString());
        }
    }

    /* private void ThrowProjectile(Vector2 dir)
     {
         if (projectiles.Count > 0)
         {
             int num = 1;
             bool flipX = player.GetComponent<SpriteRenderer>().flipX;

             projectiles[num].gameObject.SetActive(true);
             projectiles[num].gameObject.GetComponent<SpriteRenderer>().flipX = flipX;
             projectiles[num].gameObject.transform.position = dir;

             float velocityX = flipX ? -20f : 20f;
             projectiles[num].GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, 0);

             projectiles.RemoveAt(num);
         }
     }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            string ProjectileName = collision.transform.name;
            string names =  ProjectileName.Replace("(Clone)", "");
            if (!projectileName.Contains(names))
            {
                projectileName.Add(names);
            }

            if (!projectileHolders.ContainsKey(names))
            {
         
                projectileHolders[names]  = new List<Transform>();
            }
            projectileHolders[names].Add(collision.transform);
            
            UpdateUI(names);
            projectiles.Add(collision.transform);
             
            collision.gameObject.SetActive(false);
        }
    }

    private void UpdateUI(string name)
    {
       
        if ( projectileHolders.ContainsKey(name))
        {
            if (projectileHolders[name].Count > 0)
            {
                image.sprite = projectileHolders[name][0].GetComponent<SpriteRenderer>().sprite;
                Uitext.text = projectileHolders[name].Count.ToString();
            }
            else
            {
                image.sprite = null;
                Uitext.text = "0" ;
            }
        }
    }
   
    private void DisableClone()
    {
       
        foreach (var kvp in projectileHolders)
        {
         
            foreach (Transform transform in kvp.Value)
            {
               transform.gameObject.SetActive(false);
            }
        }
    }
}
