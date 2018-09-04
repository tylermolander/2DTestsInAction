using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerConroller : MonoBehaviour {

    public float speed = 250f;
    public float jumpForce = 12f;
    private Rigidbody2D myRigidBody;
    private BoxCollider2D boxCollider;


	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, myRigidBody.velocity.y);
        myRigidBody.velocity = movement;


        Vector3 max = boxCollider.bounds.max;
        Vector3 min = boxCollider.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;

        if(hit != null)
        {
            grounded = true;
        }


        myRigidBody.gravityScale = grounded && deltaX == 0 ? 0 : 1;

        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1) ))
        {
            myRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
	}
}
