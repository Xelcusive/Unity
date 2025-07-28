using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    private int coin = 0;
    [SerializeField] private TextMeshProUGUI coinCount;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCoin();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCoin(int coins)
    {
        coin += coins;
        UpdateCoin();
    }    
    private void UpdateCoin()
    {
        coinCount.text=coin.ToString();
    }    

    
}
