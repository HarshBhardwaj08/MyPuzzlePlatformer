using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeThrowSkills : MonoBehaviour 
{
    public UnityEngine.GameObject Knifes;
    public UnityEngine.GameObject Player;
    public Image directionIndicator;
    [SerializeField] private Transform transformKnife;
    [SerializeField] private float power;
    public List<UnityEngine.GameObject> knifeDetails = new List<UnityEngine.GameObject>();
    private float timer = 0;
 
    private Animator animator;

    void Update()
    {
        timer += Time.deltaTime;
       
        KnifeThrow();
        
    }

    private void KnifeThrow()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt) && timer > 5.0f)
        {
           
            if (Player.GetComponent<SpriteRenderer>().flipX == true)
            {
                UnityEngine.GameObject knife = Instantiate(Knifes, transformKnife.position, Knifes.transform.rotation);
                KnifeThrow(knife, 1);
                knifeDetails.Add(knife);
               
            }
            else
            {
                UnityEngine.GameObject knife = Instantiate(Knifes, transformKnife.position, Quaternion.Euler(0, 0f, -90.0f));
                KnifeThrow(knife, -1);
                knifeDetails.Add(knife);
                
            }
            timer = 0;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (knifeDetails.Count > 0)
            {
                int closestKnifeIndex = FindClosestKnifeIndex();
                if (closestKnifeIndex != -1 && IsObjectOutOfFOV(knifeDetails[closestKnifeIndex].transform.position))
                {
                    animator = knifeDetails[closestKnifeIndex].GetComponent<Animator>();
                    knifeDetails[closestKnifeIndex].GetComponent<SpriteRenderer>().color = Color.red;
                    animator.SetTrigger("Teleport");
                    StartCoroutine(WaitForTeleport(0.5f, closestKnifeIndex));
                }
            }
        }
    }

    private int FindClosestKnifeIndex()
    {
        int closestIndex = -1;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < knifeDetails.Count; i++)
        {
            float distance = Vector3.Distance(Player.transform.position, knifeDetails[i].transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    bool IsObjectOutOfFOV(Vector3 objectPosition)
    {
        Camera mainCamera = Camera.main;
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(objectPosition);
        return (screenPoint.x > 0f && screenPoint.x < 1f);
    }

    private void KnifeThrow(UnityEngine.GameObject knife, float dir)
    {
        Rigidbody2D rb2d = knife.GetComponent<Rigidbody2D>();
        animator = knife.GetComponent<Animator>();
        rb2d.velocity = new Vector2(power * dir, rb2d.velocity.y);
    }

    private IEnumerator WaitForTeleport(float sec, int i)
    {
        yield return new WaitForSeconds(sec);
        Player.transform.position = knifeDetails[i].transform.position;
        knifeDetails.RemoveAt(i);
    }

    //private void UpdateDirectionIndicator()
    //{
    //    if (knifeDetails.Count > 0)
    //    {
    //        for (int i = 0; i < knifeDetails.Count; i++)
    //        {
    //            float distance = Vector3.Distance(Player.transform.position, knifeDetails[i].transform.position);
    //            Vector3 closestKnifeDirection = knifeDetails[i].transform.position - Player.transform.position;
    //            float angle = Mathf.Atan2(closestKnifeDirection.y, closestKnifeDirection.x) * Mathf.Rad2Deg;
    //            directionIndicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //            directionIndicator.enabled = true;
    //        }
           
    //    }
           
    //}
}
