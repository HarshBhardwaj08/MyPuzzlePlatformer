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
                _instance = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>();
            return _instance;

        }
    }

    private static SkillManager _instance;
    BasePlayer baseplayer;
    Clone clone;
    public SwordSkill skill { get; set ; }
    private void Awake()
    {
        clone = GetComponent<Clone>();
        skill = GetComponent<SwordSkill>();
    }
    
}
