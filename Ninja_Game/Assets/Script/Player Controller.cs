using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed=5f;
    [SerializeField] private float jumpForce=350;
    private bool isGrounded=true;
    private bool isJumnping=false;
    private bool isAttack = false;
    private float horizontal;
    private string currentAnimName;
    private int coin = 0;
    

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
            Jump();
            //attack
            Attack();
            //throw
            Throw();
        }
        Move();
        
        
        
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
     
    }
    //Hàm ném
    private void Throw()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGrounded)
        {
            ChangeAnmim("throw");
            isAttack=true;
            Invoke(nameof(ResetAttack), 0.5f);
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
    private void ChangeAnmim(string animName)
    {
        if(currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    } 
    //Hàm xử lý va chạm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }
    }
}

