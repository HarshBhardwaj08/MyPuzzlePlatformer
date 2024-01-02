using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] float coolDown;
    protected float coolDowntimer;

    public virtual void Update()
    {
        coolDowntimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if(coolDowntimer < 0)
        {
            UseSkills();
            coolDowntimer = coolDown;
            return true;
        }
        return false;
    }

    public virtual void UseSkills()
    {

    }
   
}
