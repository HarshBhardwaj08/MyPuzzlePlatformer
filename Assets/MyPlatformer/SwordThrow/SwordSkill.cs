using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : Skill
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] Vector2 LaunchDirection;
    [SerializeField] float gravity;
    
    Vector2 finalDir;
    [Header("AimDots")]
    [SerializeField] private int numberofDots;
    [SerializeField] private float spaceBetweenDots;
    [SerializeField] private GameObject dotsPrefabs;
    [SerializeField] private Transform dotsparent;
    [SerializeField] Vector2 offset;
    private GameObject[] dots;
    private void Start()
    {
        GenerateDots();
    }
    public override void Update()
    {
        base.Update();

    }
    public void ThowSword(BasePlayer player)
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            finalDir = new Vector2(GetDirection(player).normalized.x * LaunchDirection.x, GetDirection(player).normalized.y * LaunchDirection.y);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            for(int i =0; i < dots.Length; i++)
            {
                dots[i].transform.position = DotsPos(i * spaceBetweenDots, player);
            }
        }
    }

   public void CreateSword(BasePlayer player,float dir)
    {
      var sword =  Instantiate(swordPrefab, player.transform.position, transform.rotation);
        SwordController swordController = sword.GetComponent<SwordController>();

        swordController.SetDirection(LaunchDirection, gravity);

       
    }

    public Vector2 GetDirection(BasePlayer player)
    {
        Vector2 playerPos = player.transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Dir = playerPos - mousePos;
        DotsActive(false);
        return Dir;
    }
    public void GenerateDots()
    {
        dots = new GameObject[numberofDots];

        for(int i = 0; i < numberofDots; i++)
        {
            dots[i] = Instantiate(dotsPrefabs, dotsparent.transform.position, Quaternion.identity, dotsparent);
            dots[i].SetActive(false);
        }
    }

    private Vector2 DotsPos(float t,BasePlayer player)
    {
        Vector2 pos = (Vector2)player.transform.position +
            new Vector2(GetDirection(player).normalized.x * LaunchDirection.x,
            GetDirection(player).normalized.y * LaunchDirection.y) * t + .5f *
            (Physics2D.gravity * gravity) * (t * t);
        
        return pos;
    }

    public void DotsActive(bool _isActive)
    {
        for(int i = 0; i < dots.Length; i++)
        {
            dots[i].SetActive(true);
        }
    }
}
