using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gameManager.AddCoin(20);
        }    
        if(collision.CompareTag("DeathZone"))
        {
            playerController.CallChangeAnim("die");
        }    
    }
}
