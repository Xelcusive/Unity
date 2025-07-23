using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    private IState currentState;
    private Character target;
    private bool isRight = true;
    public Character Target => target;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState !=null)
        {
            currentState.OnExecute(this);
        }    
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeSate(new IdleState());
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
    }
    protected override void OnDeath()
    {
        base.OnDeath();
    }
    public void ChangeSate(IState newState)
    {
      
        currentState=newState;
        
        if(currentState!=null)
        {
            currentState.OnEnter(this);
        }
    }
    public void Moving()
    {
        ChangeAnmim("run");
        rb.velocity = transform.right*moveSpeed;
    }
    public void StopMoving()
    {
        ChangeAnmim("idle");
        rb.velocity = Vector2.zero;
    }
    public void Attack()
    {
        ChangeAnmim("attack");
    }
    public bool IsTarrgetInRange()
    {
        if (target != null && Vector2.Distance(target.transform.position, transform.position) <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal void SetTarget(Character character)
    {
        this.target =character;
        if(IsTarrgetInRange())
        {
            ChangeSate(new AttackState());
        }
        else 
        {
            if(Target !=null)
            {
                ChangeSate(new PatrolState());
            }
            else
            {
                ChangeSate(new IdleState());
            }    
        } 
            
    }
    public void ChangDirection(bool isRight)
    {
        this.isRight = isRight;
        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
}

