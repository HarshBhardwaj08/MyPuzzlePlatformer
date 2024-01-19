using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
  
    public void DestroyItself()
    {
        Destroy(this.gameObject);
    }
}
