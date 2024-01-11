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
    [SerializeField] private int count = 0;
    private float timer = 0;
    private bool isThrow;
    private Animator animator;
    public Vector3 camSize;
   
    private void Start()
    {
        //camSize = CalculateViewportSize();
    }
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(isThrow);
        KnifeThrow();
    }

    private void KnifeThrow()
    {
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

        
        

        if (Input.GetKeyUp(KeyCode.E) )
        {
            for(int i=0;i < knifeDetails.Count; i++)
            {
                if (IsObjectOutOfFOV(knifeDetails[i].transform.position))
                {
                    isThrow = true;
                }
                else
                {
                    isThrow = false;
                }
                animator.SetTrigger("Teleport");
                StartCoroutine(WaitForTeleport(0.5f, i));
            }
        }
    }

    bool IsObjectOutOfFOV(Vector3 objectPosition)
    {
        Camera mainCamera = Camera.main;
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(objectPosition);
        if (screenPoint.x > 0f && screenPoint.x < 1f )
        {
            return true;
        }
        return false;
    }

    private void KnifeThrow(GameObject knife,float dir)
    {
        Rigidbody2D rb2d = knife.GetComponent<Rigidbody2D>();
        animator = knife.GetComponent<Animator>();
        rb2d.velocity = new Vector2(power*dir, rb2d.velocity.y);
        knifeDetails.Remove(knife);
    } 
    private IEnumerator WaitForTeleport(float sec, int i)
    {
        yield return new WaitForSeconds(sec);
        
            Player.transform.position = knifeDetails[i].transform.position;
        knifeDetails.Remove(this.knifeDetails[i]);
    }
}
