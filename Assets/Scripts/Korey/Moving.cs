using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Moving : MonoBehaviour
{
    public const float SprintSpeed = 4;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer sprite;

    private float speed = 4;
    private float horizontal;
    private bool isSprintig;
    private bool isJumping;
    private bool endOfAnimation;
    private bool lowerKick;
    private bool isGrounded = true;
    private bool isMoving;

    private void Update()
    {
        this.horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        MovingCharacter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "FloorCollider")
        {
            this.isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FloorCollider"))
        {
            this.isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FloorCollider"))
        {
            this.isGrounded = true;
        }
    }

    private void MovingCharacter()
    {
        if (this.horizontal != 0)
        {
            this.transform.Translate(new Vector2(this.horizontal * this.speed * Time.deltaTime, 0f));
            if (this.horizontal < 0)
            {
                this.sprite.flipX = true;
            }
            else
            {
                this.sprite.flipX = false;
            }

            this.isSprintig = true;
        }
        else
        {
            this.isSprintig = false;
        }

        this.animator.SetFloat("Sprint", Mathf.Abs(this.horizontal));
        this.animator.SetFloat("Walking", Mathf.Abs(this.horizontal));
        this.animator.SetBool("Idle", this.isSprintig);
    }
}