using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : MonoBehaviour
{ 
    public static SkillManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SkillManager();
            return _instance;

        }
    }

    private static SkillManager _instance;
    Clone clone;

    private void Start()
    {
        clone = GetComponent<Clone>();
    }
}
