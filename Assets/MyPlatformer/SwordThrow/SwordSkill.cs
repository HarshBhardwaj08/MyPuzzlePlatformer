using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : Skill
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] Vector2 LaunchDirection;
    [SerializeField] float gravity;

   

   public void CreateSword(BasePlayer player,float dir)
    {
      var sword =  Instantiate(swordPrefab, player.transform.position, transform.rotation);
        SwordController swordController = sword.GetComponent<SwordController>();

        swordController.SetDirection(LaunchDirection*dir, gravity);

       
    }

    public Vector2 GetDirection(BasePlayer player)
    {
        Vector2 playerPos = player.transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Dir = playerPos - mousePos;
        return Dir;
    }
}
