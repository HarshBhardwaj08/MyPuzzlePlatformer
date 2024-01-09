using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackHoleHotKey : MonoBehaviour
{
    private KeyCode hotkey;
    public TextMeshProUGUI hotkeyUGI;
    private Transform myEnemy;
    private GameObject clone;
    private BlackHoleController _BlackHoleController;
    void Update()
    {
        if (Input.GetKeyDown(hotkey))
        {
            Debug.Log("hotkeyPressed" + hotkey);
            GameObject enemies = Instantiate(clone, myEnemy.transform.position, Quaternion.identity);
            if (myEnemy.GetComponent<SkeletonEnemy>().playerDir > 0)
            {   
                enemies.transform.Rotate(0, 0, 0);
            }
            else
            {
                enemies.transform.Rotate(0, 180, 0);
            }
          //  _BlackHoleController.enemies.Add(myEnemy);
           // SignalManager.Instance.Notify("AttackClone");
            Destroy(this.gameObject);
        }
    }
    public void setUpHotKey(KeyCode _myHotKey,Transform _myEnemy, BlackHoleController blackHoleController, GameObject clones)
    {
        hotkey = _myHotKey;
        hotkeyUGI.text = hotkey.ToString();
        this.clone = clones;
        this.myEnemy = _myEnemy;
        this._BlackHoleController = blackHoleController;
    }
}
