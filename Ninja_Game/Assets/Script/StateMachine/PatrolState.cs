using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    float randomTime;
    float timer;
    public void OnEnter(Enemy enemy)
    {
        timer = 0;
        randomTime = Random.Range(3f, 6f);
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (enemy.Target != null)
        {
            //Đổi hướng enemy tới hướng của player
            enemy.ChangDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
            if (enemy.Target != null)
            {
                if (enemy.IsTarrgetInRange())
                {
                    enemy.ChangeSate(new AttackState());
                }

            }
            else
            {
                enemy.Moving();
            }
        }
        else
        {
            if (timer < randomTime)
            {
                enemy.Moving();
            }
            else
            {
                enemy.ChangeSate(new IdleState());
            }
        }
    }

    public void OnExit(Enemy enemy)
    {
        
    }


    
}
