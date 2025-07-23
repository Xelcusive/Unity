using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float randomTime;
    float timer;
    public void OnEnter(Enemy ennemy)
    {
       ennemy.StopMoving();
        timer = 0;
        randomTime = Random.Range(2f, 4f);
    }


    public void OnExecute(Enemy ennemy)
    {
        timer += Time.deltaTime;
        if (timer>randomTime)
        {
            ennemy.ChangeSate(new PatrolState());
        }
    }

    public void OnExit(Enemy ennemy)
    {
        throw new System.NotImplementedException();
    }


}
