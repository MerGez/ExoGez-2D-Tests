using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float moveSpeed = 10f;
    public float smoothFactor = 2;

    private bool faceRight = true;
    private Rigidbody2D rb2d;
    private Animator anim;


	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jumpTrigger");
        }

    }

    private void Move()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        Vector2 playerDirection = new Vector2(xMovement, yMovement);

        transform.Translate(Vector2.Lerp(transform.position, playerDirection * moveSpeed * Time.deltaTime, smoothFactor));
        anim.SetFloat("xMoveSpeed",Mathf.Abs(xMovement));

        if (xMovement > 0 && !faceRight)
            flip();
        else if (xMovement < 0 && faceRight)
            flip();
    }

    void flip()
    {
        faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
