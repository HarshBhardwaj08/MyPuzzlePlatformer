using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : SingleteornClass<SkillManager>
{ 
   
    BasePlayer baseplayer;
    Clone clone;
    public SwordSkill skill { get; set ; }
    protected override void Awake()
    {
        clone = GetComponent<Clone>();
        skill = GetComponent<SwordSkill>();
    }
    
}
