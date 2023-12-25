using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObeservable 
{
    void add(IObserver observer);
    void remove(IObserver observer);
    void Notify();
}
