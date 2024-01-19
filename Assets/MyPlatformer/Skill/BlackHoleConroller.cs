using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    [SerializeField] UnityEngine.GameObject Clones;
    [SerializeField] UnityEngine.GameObject hotkeysPrefabs;
    [SerializeField] private List<KeyCode> keyCodeslist;
    public float minSize;
    public float maxSize;
    public float growSpeed;
    public bool canGrow;

    public List<Transform> enemies = new List<Transform>();
    public List<UnityEngine.GameObject> blackHoleHotKeys = new List<UnityEngine.GameObject>();
    private void OnEnable()
    {
       //SignalManager.Instance.SubscribeToPublishers(this);
        minSize = transform.localScale.x;
    }

    private void OnDisable()
    {
       // SignalManager.Instance.UnSubscribeToPublishers(this);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            destroyHotKEys();
            canGrow = false;
        }
        if (canGrow == true)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize,maxSize), growSpeed*Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(minSize, minSize), growSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
          
            collision.gameObject.GetComponent<SkeletonEnemy>().freezeEnemy(true);
            UnityEngine.GameObject newHotKey = Instantiate(hotkeysPrefabs, collision.transform.position + new Vector3(0, 1.0f), Quaternion.identity);
            blackHoleHotKeys.Add(newHotKey);
            KeyCode choosenkey = keyCodeslist[Random.Range(0, keyCodeslist.Count)];
            keyCodeslist.Remove(choosenkey);

            BlackHoleHotKey newblackHoleHotKey = newHotKey.GetComponent<BlackHoleHotKey>();
           
            newblackHoleHotKey.setUpHotKey(choosenkey,collision.transform,this, Clones);
            
            //enemies.Add(collision.transform);
        }
    }

    void destroyHotKEys()
    {
      for(int i = 0;i < blackHoleHotKeys.Count;i++)
        {
            Destroy(blackHoleHotKeys[i]);
        }
    }
}
 