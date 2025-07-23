using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float randomTime;
    float timer;
    public void OnEnter(Ennemy ennemy)
    {
       ennemy.StopMoving();
        timer = 0;
        randomTime = Random.Range(2f, 4f);
    }


    public void OnExecute(Ennemy ennemy)
    {
        timer += Time.deltaTime;
        if (timer>randomTime)
        {
            ennemy.ChangeSate(new PatrolSate());
        }
    }

    public void OnExit(Ennemy ennemy)
    {
        throw new System.NotImplementedException();
    }


}
