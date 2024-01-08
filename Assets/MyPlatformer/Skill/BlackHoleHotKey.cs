using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackHoleHotKey : MonoBehaviour
{
    private KeyCode hotkey;
    public TextMeshProUGUI hotkeyUGI;
    private Transform myEnemy;
    private BlackHoleController _BlackHoleController;
    void Update()
    {
        if (Input.GetKeyDown(hotkey))
        {
            Debug.Log("hotkeyPressed" + hotkey);
            _BlackHoleController.enemies.Add(myEnemy);
            SignalManager.Instance.Notify("AttackClone");
        }
    }
    public void setUpHotKey(KeyCode _myHotKey,Transform _myEnemy, BlackHoleController blackHoleController)
    {
        hotkey = _myHotKey;
        hotkeyUGI.text = hotkey.ToString();
        
        this.myEnemy = _myEnemy;
        this._BlackHoleController = blackHoleController;
    }
}
