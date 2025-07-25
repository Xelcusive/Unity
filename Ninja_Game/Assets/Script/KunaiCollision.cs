using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiCollision : Kunai
{
    public GameObject hitVFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Character>().OnHit(30f);
            Instantiate(hitVFX, transform.position, transform.rotation);
            OnDespawn(); 
        }
    }
}
