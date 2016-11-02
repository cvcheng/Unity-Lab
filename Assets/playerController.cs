using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{

    public Rigidbody2D rigid;
    public float speed = 7.0f;
    public bool isFacingRight = false;
    public float force = 5.0f;
    public bool jump;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame, better for input
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    // FixedUpdate is better for physics and movement
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigid.velocity.y);
        rigid.velocity = new Vector2(rigid.velocity.x, Input.GetAxis("Vertical") * speed);

        if ((Input.GetAxis("Horizontal") < 0 && !isFacingRight) || (Input.GetAxis("Horizontal") > 0 && isFacingRight))
            Flip();

        if (jump)
        {
            //rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.transform.Translate(Vector3.up * 75 * Time.deltaTime, Space.World);

            jump = false;
        }
    }

    void Flip()
    {
        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
        isFacingRight = !isFacingRight;
    }

}