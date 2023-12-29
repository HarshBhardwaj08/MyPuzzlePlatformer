using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour,IObserver
{
    Rigidbody2D rg2d;
    public Transform areaCollision;
    Vector3 initalPos;
    private void Awake()
    {
        initalPos = this.transform.position;
        rg2d = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        SignalManager.Instance.SubscribeToPublishers(this);
    }

    private void OnDisable()
    {
        SignalManager.Instance.UnSubscribeToPublishers(this);
    }

    public void getUpdate(string signal)
    {
        if (signal == "Smasher") { smash(); }
    }
   
    void smash()
    {
     Vector2 newPos = Vector2.MoveTowards(transform.position,areaCollision.position , 50f);

        rg2d.MovePosition(newPos);
        SignalManager.Instance.Notify("CameraShake");
        Invoke("ResetPos", 2.0f);
    }
   void ResetPos()
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position,initalPos , 50f );
        rg2d.MovePosition(newPos);
        //transform.position = newPos;
    }
}
