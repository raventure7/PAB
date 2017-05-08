using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public bool isFactingRight = true;
    [HideInInspector]
    public bool isJumping = false;
    [HideInInspector]
    public bool isGrounded = false;
    [HideInInspector]
    public bool isPlay = false;

    public Sprite DieImage;


    public float maxSpeed;
    public float jumpForce;

    public Camera mainCamera;
    public Transform groundCheck;
    public LayerMask groundLayers; // 게임오브젝트가 지면에 있는지 알 수 있는 레이어 리스트
    private float groundCheckRadius = 0.2f;
    private Animator anim;
    float move;

    bool isDead = false;
    
    public bool IsDead()
    {
        return isDead;
        
    }

    
    private void Awake()
    {
        anim = this.GetComponentInChildren<Animator>();
        
    }
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate() {
        if(!isDead)
        { 
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);
#if    UNITY_EDITOR
            move = Input.GetAxis("Horizontal");
#endif 
#if    UNITY_ANDROID
            move = CrossPlatformInputManager.GetAxis("Horizontal");
#endif

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

            
            if ((move > 0.0f && isFactingRight == false) || (move < 0.0f && isFactingRight == true))
            {
                Flip();
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true && !isDead)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

                anim.SetTrigger("Jump");
                //
            }

        }
        if (CrossPlatformInputManager.GetButton("Jump"))
        {
            if (isGrounded == true && !isDead)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

                anim.SetTrigger("Jump");
                
            }
        }
        if (CrossPlatformInputManager.GetButtonUp("Jump"))
        {

        }

    }
    // 방향 전환
    void Flip()
    {
        isFactingRight = !isFactingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
    }
    
    public void ShieldDestory()
    {
        GameObject Shield = this.transform.FindChild("Shield").gameObject;
        Destroy(Shield);
    }
    //  충돌 체크
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // 본격 플레이 중일 때
        if (isPlay)
        { 
            // 응가랑 충돌 하면 게임 오버 처리
            if(collider.tag == "Poop")
            {

                if (isDead) return;
                isDead = true;



                // 애니메이션 처리
                //anim.SetBool("Die", true);
                // 스케일 처리
                GameObject sprt = (GameObject)this.transform.FindChild("Sprite").gameObject;
                sprt.GetComponent<SpriteRenderer>().sprite = DieImage;
                Destroy(sprt.GetComponent<Animator>());
                sprt.transform.localScale = new Vector3(3, 3, 3);
                Destroy(collider.gameObject);
            }
        }


    }
}
