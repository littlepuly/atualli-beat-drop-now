using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isFacingRight;

    bool isgrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float jumpButtonGracePeriod;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    public float dashDistance;
    public float dashTime;
    bool isDashing;

    private GameManager gm;

    private GameObject[] bits;

    private PlayerManager pm;

    private Animator anim;
    private AudioSource aus;

    private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        pm = GetComponent<PlayerManager>();
        anim = GetComponent<Animator>();
        aus = GetComponent<AudioSource>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        bits = GameObject.FindGameObjectsWithTag("bit");

        if (isgrounded)
        {
            lastGroundedTime = Time.time;
            anim.SetBool("falling", false);
        }
        else if(!isgrounded)
        {
            anim.SetBool("falling", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jump();
        }


        if(Input.GetMouseButtonDown(1))
        {
            if(bits.Length != 0)
            {

                gm.scoreMult++;

                if (isFacingRight == false)
                {
                    StartCoroutine(dash(1f));
                }
                else if (isFacingRight == true)
                {
                    StartCoroutine(dash(-1f));
                }
            }
            else
            {
                gm.scoreMult = 1;
            }
        }

    }

    private void FixedUpdate()
    {

        isgrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        if (!isDashing)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

        if (isFacingRight == false && moveInput < 0)
        {
            flip();
        }
        else if (isFacingRight == true && moveInput > 0)
        {
            flip();
        }

    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void jump()
    {
        if(Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            anim.SetTrigger("jump");
            rb.velocity = Vector2.up * jumpForce;
            jumpButtonPressedTime = null;
            lastGroundedTime = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }


    IEnumerator dash (float direction)
    {
        isDashing = true;
        tr.enabled = true;
        aus.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(dashDistance * direction, 0), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        tr.enabled = false;
        rb.gravityScale = gravity;
    }

    public IEnumerator knockBack(float duration, float power, Transform obj)
    {
        float timer  = 0f;

        while(duration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.position - this.transform.position).normalized;
            rb.AddForce(-direction * power);

            yield return 0;
        }
    }
}
