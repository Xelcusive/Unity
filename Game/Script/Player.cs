using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed=5f;
    [SerializeField] private float jumpForce = 350;
    private bool isGrounded=true;
    private bool isJumping=false;
    private bool isAtack=true;
    private float horizontal;
    private string currentAnimName;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = checkGrounded();
        //-1--> 0 --> 1
        horizontal = Input.GetAxisRaw("Horizontal");
        if (isGrounded)
        {
            if (isJumping)
            {
                return;
            }
            //jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
                ChangeAnim("jump");
                rb.AddForce(jumpForce * Vector2.up);
            }

            if (Mathf.Abs(horizontal) > 0.1f)
            {
                ChangeAnim("run");

            }
            if (Input.GetKeyDown(KeyCode.F) && isGrounded)
                Atack();
            if (Input.GetKeyDown(KeyCode.G) && isGrounded)
                Throw();
            
        }
        //Check falling
        if (isGrounded && rb.linearVelocity.y < 0)
        {
            ChangeAnim("fall");
            isJumping = false;
        }

        //Moving
        if (Mathf.Abs(horizontal) > 0.1f)
        {
                ChangeAnim("run");
                rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
                //Horizontal >0 --> trả về 0, nếu horizontal <=0 --> trả về 180
                transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
        }
        else if (isGrounded)
        {
                ChangeAnim("idle");
                Debug.Log("zero");
                rb.linearVelocity = Vector2.zero;
        }
        
    }
    private bool checkGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down*1.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,1.1f,groundLayer);

        //if(hit!=null)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return hit.collider !=null;
    }
    private void Atack()
    {
        ChangeAnim("attack");
        isAtack = true;
        Invoke(nameof(ResetAttack),0.5f);
    }
    private void Throw()
    {

        ChangeAnim("throw");
        isAtack=false;
        Invoke(nameof(ResetAttack), 0.5f);

    }
    private void ResetAttack()
    {
        isAtack = false;
        ChangeAnim("idle");
    }
    private void ChangeAnim(string animName)
    {
        if(currentAnimName != animName)
        {
            anim.ResetTrigger(currentAnimName); //reset cái cũ
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName); //set cái mới
        }
    }
}
