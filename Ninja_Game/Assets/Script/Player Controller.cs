using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed=5f;
    [SerializeField] private float jumpForce=350;
    [SerializeField] private Kunai kunaiPrefab;
    [SerializeField] private Transform throwpoint;
    [SerializeField] private GameObject attackArea;
    private bool isGrounded=true;
    private bool isJumnping=false;
    private bool isAttack = false;
    private bool isDeath = false;
    private float horizontal;
    private Vector3 savePoint;

    public Rigidbody2D RB;
    public bool IsDeath;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckGrounded();
        Falling();
        if (isGrounded)
        {
            //Jump
            Jump();
            //attack
            Attack();
            //throw
            Throw();
        }
        Move();
    }
    public void OnInit()// hàm reset các thông số, đưa về trạng thái đầu tiên
    {
        isDeath = false;
        isDeath = false;
        isAttack = false;
        transform.position = savePoint;
        ChangeAnmim("Idle");
        DeActiveAttack();

        RB = rb;
        SavePoint();
    }
    //Hàm check nhân vật có ở mặt đất hay là không
    private bool CheckGrounded()
    {
        
       Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f,Color.red);
       RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
            //if(hit !=null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;   
            //}
       return hit.collider !=null;
        
    }

    //Hàm di chuyển
    private void Move()
    {

        //Di chuyển theo trục x
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Mathf.Abs(horizontal) > 0.1f)
        {
            ChangeAnmim("run");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            transform.rotation= Quaternion.Euler(new Vector3(0,horizontal>0 ? 0:180,0));
        }
        else if(isGrounded) 
        {
            ChangeAnmim("idle");
            rb.velocity=Vector2.zero;
        }
    }

    //Hàm tấn công
    private void Attack()
    {
        if (isAttack)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (Input.GetKeyDown(KeyCode.E)&&isGrounded)
        { 
            ChangeAnmim("attack");
            isAttack= true;
            Invoke(nameof(ResetAttack), 0.5f);
        }
        ActiveAttack();
        Invoke(nameof(DeActiveAttack), 0.5f);
     
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        OnInit();
    }
    protected override void OnDeath()
    {
        base.OnDeath();
    }
    //Hàm ném
    private void Throw()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGrounded)
        {
            ChangeAnmim("throw");
            isAttack=true;
            Invoke(nameof(ResetAttack), 0.5f);

            Instantiate(kunaiPrefab, throwpoint.position, throwpoint.rotation);
        }
      
    }
    //Hàm nhảy
    private void Jump()
    {
        if (isJumnping)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumnping = true;
            ChangeAnmim("jump");
            rb.AddForce(jumpForce * Vector2.up);
        }
        
        //Change anim run
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            ChangeAnmim("run");
        }

    }
    private void Falling()
    {
        if (!isGrounded && rb.velocity.y < 0)
        {
            ChangeAnmim("fall");
            isJumnping = false;
        }
    }
    private void ResetAttack()
    {
        isAttack=false;
        ChangeAnmim("idle");

    }
    public void CallChangeAnim(string animName)//Gọi gián tiếp changeAnim để dùng cho collision
    {
        ChangeAnmim(animName);
    }     

    internal void SavePoint()
    {
        savePoint=transform.position;
    }

    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }
    private void DeActiveAttack()
    {
        attackArea.SetActive(false);
    }
}

