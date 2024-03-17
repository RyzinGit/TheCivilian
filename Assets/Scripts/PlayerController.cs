using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim;
	float dirX, moveSpeed = 5f;
	int  healthPoints = 3;
	bool isHurting, isDead;
	bool facingRight = true;
    bool disableJump = false;
	Vector3 localScale;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		localScale = transform.localScale;
	}
	
	void Update () {		

		if (Input.GetButtonDown ("Jump") && !isDead && rb.velocity.y < 0.1f && !disableJump){
            disableJump = true;
            StartCoroutine ("EnableJump");
			rb.AddForce (Vector2.up * 300f);
        }

		SetAnimationState ();

		if (!isDead)
			dirX = Input.GetAxisRaw ("Horizontal") * moveSpeed;
	}

	void FixedUpdate()
	{
		if (!isHurting)
			rb.velocity = new Vector2 (dirX, rb.velocity.y);
	}

	void LateUpdate()
	{
		CheckWhereToFace();
	}

	void SetAnimationState()
	{
		if (dirX == 0) {
			anim.SetBool ("isRunning", false);
		}

		if (rb.velocity.y == 0) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", false);
		}

		if ((rb.velocity.x > 0.5f || rb.velocity.x < -0.5f) && rb.velocity.y < 0.5f)
			anim.SetBool ("isRunning", true);

		if (rb.velocity.y > 0.5f)
			anim.SetBool ("isJumping", true);
		
		if (rb.velocity.y < 0) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", true);
		}
	}

	void CheckWhereToFace()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name.Equals ("Fire")) {
			healthPoints -= 1;

            if(healthPoints == 0)
            {
                isDead = true;
                anim.SetTrigger("isDead");
            }
            else
            {
                anim.SetTrigger("isTakenHit");
                StartCoroutine("Hurt");
            }
		}

        if(col.gameObject.name.Equals("EndLevel"))
        {
            Debug.Log("End of level");
        }
        if(col.gameObject.tag == "Civilian")
        {
            Debug.Log("Civilian collected");
			//fade out civilian's sprite
			//increase score
        }
	}

	IEnumerator Hurt()
	{
		isHurting = true;
		rb.velocity = Vector2.zero;

		if (facingRight)
			rb.AddForce (new Vector2(-200f, 200f));
		else
			rb.AddForce (new Vector2(200f, 200f));
		
		yield return new WaitForSeconds (0.5f);

		isHurting = false;
	}

    	IEnumerator EnableJump()
	{
        yield return new WaitForSeconds (1.2f);
		disableJump = false;
	}

}
