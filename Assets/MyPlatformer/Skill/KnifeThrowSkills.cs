using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrowSkills : MonoBehaviour 
{
    public GameObject Knifes;
    public GameObject Player;
    [SerializeField] private Transform transformKnife;
    [SerializeField] private float power;
    public List<GameObject> knifeDetails = new List<GameObject>();
    int count = -1;
    private float timer = 0;
    private bool isThrow;
    private Animator animator;
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.RightAlt) && timer > 5.0f)
        {
            isThrow = true;
            if (Player.GetComponent<SpriteRenderer>().flipX == true)
            {
                GameObject knife = Instantiate(Knifes, transformKnife.position, Knifes.transform.rotation);
                KnifeThrow(knife, 1);
                knifeDetails.Add(knife);
                count++;
            }

            else
            {
                GameObject knife = Instantiate(Knifes, transformKnife.position, Quaternion.Euler(0, 0f, -90.0f));
                KnifeThrow(knife, -1);
                knifeDetails.Add(knife);
                count++;
            }
            timer = 0;
        }
       
        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetTrigger("Teleport");
            StartCoroutine(WaitForTeleport(0.5f));
            isThrow = false;
          
        }
    }


    private void KnifeThrow(GameObject knife,float dir)
    {
        Rigidbody2D rb2d = knife.GetComponent<Rigidbody2D>();
        animator = knife.GetComponent<Animator>();
        rb2d.velocity = new Vector2(power*dir, rb2d.velocity.y);

    }
    private IEnumerator WaitForTeleport(float sec)
    {
        yield return new WaitForSeconds(sec);
        Player.transform.position = knifeDetails[count].transform.position ;
       

    }
}
