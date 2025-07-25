using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;
    //[SerializeField] private GameManager healthBar;
    private float hp;
    private string currentAnimName;
    public bool IsDead => hp <= 0;

    private void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        hp = 100;
        //healthBar.OnInit(100);
    }

    public virtual void OnDespawn()
    {

    }
    protected void ChangeAnmim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
    public void OnHit(float damage)
    {
        if(!IsDead)
        {
            hp-=damage;
            if(hp<=damage)
            {
                OnDeath();
            }
        }
    }


    protected virtual void OnDeath()
    {
        ChangeAnmim("die");
        Invoke(nameof(OnDespawn), 2f);
    }
   
}
