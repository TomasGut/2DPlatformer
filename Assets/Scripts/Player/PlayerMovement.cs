using UnityEngine;

namespace Platformer.Characters
{
    public partial class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpForce;
        
        private float horizontalInput;
        private bool isGrounded;

        private Rigidbody2D rigidBody;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        protected void StartMovement()
        {
            this.rigidBody = GetComponent<Rigidbody2D>();
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.animator = GetComponent<Animator>();
        }

        protected void UpdateMovement()
        {
            this.horizontalInput = Input.GetAxis("Horizontal");
            
            // Update jumping
            if (Input.GetButtonDown("Jump") && this.isGrounded)
                Jump();

            // Update visuals
            this.spriteRenderer.flipX = this.horizontalInput < 0;

            //Debug.Log(this.rigidBody.linearVelocityY);

            this.animator.SetBool("IsRuning", this.horizontalInput != 0 && this.isGrounded);
            this.animator.SetBool("IsGrounded", this.isGrounded);
        }

        protected void FixedUpdateMovement()
        {
            // Update movement only on ground
            this.rigidBody.linearVelocity = new Vector2(this.horizontalInput * this.movementSpeed, this.rigidBody.linearVelocity.y);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                this.isGrounded = true;
        }

        private void Jump()
        {
            this.rigidBody.linearVelocity = new Vector2(this.rigidBody.linearVelocityX, this.jumpForce);
            this.animator.SetTrigger("Jump");
            this.isGrounded = false;
        }
    }
}