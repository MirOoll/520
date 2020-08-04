using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

	public Rigidbody2D rb;
	public float moveSpeed = 5f;
	Vector2 movement;
	
	// Update is called once per frame
	void Update ()
	{
		movement.x = Input.GetAxis("Horizontal"); 
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
