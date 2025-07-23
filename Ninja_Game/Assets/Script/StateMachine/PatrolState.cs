using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    float randomTime;
    float timer;
    public void OnEnter(Ennemy ennemy)
    {
        timer = 0;
        randomTime = Random.Range(3f, 6f);
    }

    public void OnExecute(Ennemy ennemy)
    {
        timer += Time.deltaTime;
        if (timer < randomTime)
        {
            ennemy.Moving();
        }
        else
        {
            ennemy.ChangeSate(new IdleState());
        }
    }

    public void OnExit(Ennemy ennemy)
    {
        throw new System.NotImplementedException();
    }


    
}
