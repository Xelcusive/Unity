using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image imageFill;
    [SerializeField] Vector3 offset;
    float hp;
    float maxHP;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || imageFill == null) return;

        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp/maxHP, Time.deltaTime*5f);
        transform.position =target.position + offset;
    }
    public void OnInit(float maxHP, Transform target)
    {
        this.target = target;
        this.maxHP = maxHP;
        hp =maxHP;
        imageFill.fillAmount = 1;
    }
    public void SetNewHP(float hp)
    {
        this.hp = hp;
        //imageFill.fillAmount = hp/maxHP;
    }
}
