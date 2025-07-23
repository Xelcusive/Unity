using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Character
{
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    private IState currentState;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(currentState!= null)
        {
            currentState=newState;
        }
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

    }
    public bool IsTarrgetInRange()
    {
        return false;
    }
}

