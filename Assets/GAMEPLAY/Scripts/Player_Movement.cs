using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityScript.Macros;

public class Player_Movement : MonoBehaviour
{
	public Animator animator;
	public SpriteRenderer sprite;
	public Rigidbody2D rb;

	public GameObject groundCheck;
	private bool isGrounded;
	public float moveSpeed = 5f;
	public float jumpSpeed = 5f;
	Vector2 movement;
	
	void Update ()
	{
		movement.x = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") && isGrounded == true )
		{
			rb.velocity = Vector2.up * jumpSpeed;
			isGrounded = false;
		}
		flipSprite();
		animator.SetFloat("Speed", Mathf.Abs(movement.x * 2));
		
	}

	void FixedUpdate()
	{
		//rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
		Debug.Log(isGrounded);
	}

	public void OnCollisionEnter(Collider2D other)
	{
		if (other.tag == "Ground")
		{
			isGrounded = true;
		}		
	}

	void flipSprite()
	{
		if (movement.x > 0)
		{
			sprite.flipX = false;
		}
		if (movement.x < 0)
		{
			sprite.flipX = true;
		}
	}
}
