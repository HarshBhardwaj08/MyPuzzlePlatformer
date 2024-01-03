using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : Skill
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] Vector2 LaunchDirection;
    [SerializeField] float gravity;

   

   public void CreateSword(BasePlayer player)
    {
      var sword =  Instantiate(swordPrefab, player.transform.position, player.transform.rotation);
        SwordController swordController = sword.GetComponent<SwordController>();

        swordController.SetDirection(LaunchDirection, gravity);

       
    }
}
