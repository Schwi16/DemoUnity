using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D Rigid;
    public float jumpForce = 2f;
    //public bool isJumping = false;
    //public bool isFaceRight = true;
    public PlayerDirection PlayerDirection;
    public PlayerState PlayerState;
    public JumpState JumpState;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDirection = PlayerDirection.isRight;
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerState = PlayerState.Move;
            PlayerDirection = Input.GetKey(KeyCode.RightArrow) ? PlayerDirection.isRight : PlayerDirection.isLeft;
            ChangeDirection();
            transform.position += Vector3.right * (int)PlayerDirection * speed * Time.deltaTime;
        }
        else
        {
            PlayerState = PlayerState.Idle;
        }

        if (Input.GetKeyDown(KeyCode.Space) && JumpState == JumpState.Landing)
        {
            Rigid.AddForce(Vector3.up * jumpForce);
        }
    }

    private void  OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            JumpState = JumpState.Landing;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            JumpState = JumpState.OnTheAir;
        }
    }
    void ChangeDirection()
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * (int)PlayerDirection,
            transform.localScale.y, transform.localScale.z);
    }
}

public enum PlayerState
{
    Idle,
    Move,
}
public enum JumpState
{
    OnTheAir,
    Landing
}
public enum PlayerDirection
{
    isLeft = -1,
    isRight = 1
}
