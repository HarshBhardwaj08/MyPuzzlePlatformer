using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publishers : MonoBehaviour, IObeservable
{ 
    List<IObserver> observers = new List<IObserver>();
    public void add(IObserver observer)
    {
        observers.Add(observer);
    }
    public void remove(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        pickup();
    }

   void pickup()
    {
        foreach (IObserver observer in observers)
        {
           observer.getUpdate();
        }
    }
   
}
