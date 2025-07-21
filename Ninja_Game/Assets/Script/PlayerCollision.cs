using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
       
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
            playerController.IsDeath = true;
            playerController.CallChangeAnim("die");
            StartCoroutine(ResetPlayerTosavePont(1f));
            
        }    
    }
    private IEnumerator ResetPlayerTosavePont(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerController.OnInit();
    }
}
