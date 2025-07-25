﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackState : IState
{
    float timer;
    public void OnEnter(Enemy enemy)
    {
        if(enemy.Target!=null)
        {
            //Đổi hướng enemy tới hướng của player
            enemy.ChangDirection(enemy.Target.transform.position.x > enemy.transform.position.x);

            enemy.StopMoving();
            enemy.Attack();
        }
        

    }

    public void OnExecute(Enemy ennemy)
    {
        timer += Time.deltaTime;
        if(timer>=1.5f)
        {
            ennemy.ChangeSate(new PatrolState());
        }    
    }

    public void OnExit(Enemy ennemy)
    {
        throw new System.NotImplementedException();
    }


}
