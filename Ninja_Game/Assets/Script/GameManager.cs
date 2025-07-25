using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image imageFill;
    float hp;
    float maxHP;
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
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp / maxHP, Time.deltaTime * 5f);
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

    public void OnInit(float maxHP)
    {
        this.maxHP = maxHP; 
        hp= maxHP;
        imageFill.fillAmount = 1;
    }
    public void SetNewHP(float hp)
    {
        this.hp = hp;
        imageFill.fillAmount=hp/maxHP;
    }
}
