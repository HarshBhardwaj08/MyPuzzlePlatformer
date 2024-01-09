using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SignalManager
{
    private static SignalManager instance;
    public static SignalManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SignalManager();
            }
            return instance;
        }
    }

    private Dictionary<Type, List<Action<object>>> signals = new Dictionary<Type, List<Action<object>>>();

 
    public void Subscribe<T>(Action<T> listener) where T : class
    {
        Type eventType = typeof(T);
        if (!signals.ContainsKey(eventType))
        {
            signals[eventType] = new List<Action<object>>();
        }

        signals[eventType].Add(obj => {
            listener((obj as T));
        });
    }

    public void Unsubscribe<T>(Action<T> listener) where T : class
    {
        Type eventType = typeof(T);
        if (signals.ContainsKey(eventType))
        {
            signals[eventType].Remove(obj => listener(obj as T));
        }
    }

    public void Fire<T>(T signal) where T : class
    {
        Type eventType = typeof(T);
        if (signals.ContainsKey(eventType))
        {
            foreach (var listener in signals[eventType])
            {
                listener.Invoke(signal);
            }
        }
    }
}



