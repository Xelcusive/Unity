using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter(Enemy ennemy);// bắt đầu vào state
    void OnExecute(Enemy ennemy);//update state
    void OnExit(Enemy ennemy);//ext state
}
