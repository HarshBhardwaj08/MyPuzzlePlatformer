using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenPlayer : BasePlayer
{
    public static HeavenPlayer heavenPlayers;
    public bool onGround;
    public Transform shootParent;
    public override void Awake()
    {
        base.Awake();
        heavenPlayers = this;
    }
    public override void Start()
    {
        base.Start();
        if (ExtractJson.instance.data != null)
        {
          //  transform.position = ExtractJson.instance.data.checkpoint.position;
        }
        playerStateMachine.Intialize(idleState);
        initalColor = _spriteRenderer.color;
       
    }

    public override void Update()
    {
        base.Update();
        playerStateMachine.currentstate.PlayerUpdate();
        onGround = IsGrounded();
        SkillManager.Instance.skill.ThowSword(this);
    }

    public override void setVelocity(float x, float y) => rg2D.velocity = new Vector2(x, y);

    public override void flipsprite(bool isflip) => _spriteRenderer.flipX = isflip;

    public override bool IsGrounded() => Physics2D.OverlapCircle(groundcheckpoint.position, 0.2f, mask);

    public override void Damage()
    {
        base.Damage();
        playerStateMachine.ChangeState(this.playerHurtState);


    }
    void IntialColor()
    {
        _spriteRenderer.color = initalColor;
    }

    public override void Isattacking()
    {
        base.Isattacking();
    }
    public override void Swordthrow() => SkillManager.Instance.skill.CreateSword(this,1);

}
