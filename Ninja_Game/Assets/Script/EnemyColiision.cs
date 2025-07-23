using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyColiision : MonoBehaviour
{
    private bool isRight=true; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EWall"))
        {
            Debug.Log("Enemy hit the wall");
            ChangDirection(!isRight);
        }    
    }

    public void ChangDirection(bool isRight)
    {
        this.isRight=isRight;
        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
}
