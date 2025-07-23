using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter(Ennemy ennemy);// bắt đầu vào state
    void OnExecute(Ennemy ennemy);//update state
    void OnExit(Ennemy ennemy);//ext state
}
