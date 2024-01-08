using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour,IObserver
{
    [SerializeField] GameObject Clones;
    [SerializeField] GameObject hotkeysPrefabs;
    [SerializeField] private List<KeyCode> keyCodeslist;
    public float maxSize;
    public float growSpeed;
    public bool canGrow;

    public List<Transform> enemies = new List<Transform>();
    private void OnEnable()
    {
        SignalManager.Instance.SubscribeToPublishers(this);
    }

    private void OnDisable()
    {
        SignalManager.Instance.UnSubscribeToPublishers(this);
    }
    void Update()
    {
        if (canGrow)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize,maxSize), growSpeed*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
          
            collision.gameObject.GetComponent<SkeletonEnemy>().freezeEnemy(true);
            GameObject newHotKey = Instantiate(hotkeysPrefabs, collision.transform.position + new Vector3(0, 1.0f), Quaternion.identity);
           
            KeyCode choosenkey = keyCodeslist[Random.Range(0, keyCodeslist.Count)];
            keyCodeslist.Remove(choosenkey);

            BlackHoleHotKey newblackHoleHotKey = newHotKey.GetComponent<BlackHoleHotKey>();

            newblackHoleHotKey.setUpHotKey(choosenkey,collision.transform,this);
           
            //enemies.Add(collision.transform);
        }
    }

    public void getUpdate(string signal)
    {
       if(signal == "AttackClone")
        {
           for(int i = 0; i <= enemies.Count-i; i++)
            {
                if (enemies[i].GetComponent<SkeletonEnemy>().playerDir > 0)
                {
                    GameObject clones = Instantiate(Clones, enemies[i].transform.position , Quaternion.identity);
                  
                }
                else
                {
                    GameObject clones = Instantiate(Clones, enemies[i].transform.position, Quaternion.identity);
                    clones.transform.Rotate (0, 180, 0);
                  
                }
               

            }

           
        }
    }
}
 