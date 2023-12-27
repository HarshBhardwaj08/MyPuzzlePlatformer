using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalManager 
{
    public static SignalManager Instance
    {
        get
        {
            if (instance == null)
                instance = new SignalManager() ;
            return instance;

        }
    }
    
    private static SignalManager instance;
    
    Publishers publishers = new Publishers();
   

    public void SubscribeToPublishers(IObserver observer)
    {
        publishers.add(observer);

    }
    public void UnSubscribeToPublishers(IObserver observer)
    {
        publishers.remove(observer);
    }

    public void Notify(string St)
    {
        publishers.Notify(St);
    }
}

