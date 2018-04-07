using Extensions;
using UnityEngine;

public class Player : MovingObject
{
    private Rigidbody2D rb2d;
    private bool allowedMoveUp;
    private bool allowedMoveDown;
    private bool allowedMoveLeft;
    private bool allowedMoveRight;

    protected override float ObjectSpeed
    {
        get { return 5.0f; }
    }

    // Use this for initialization
	void Start ()
	{
	    rb2d = GetComponent<Rigidbody2D>();
        allowedMoveUp = true;
        allowedMoveDown = true;
        allowedMoveLeft = true;
        allowedMoveRight = true;
    }
	
	// Update is called once per frame
    void Update()
    {
        var currentMovement = GetCurrentMovement();
        if (currentMovement.y > float.Epsilon && !allowedMoveUp) // Up
        {
            currentMovement.y = 0;
        }
        else if (currentMovement.y < -float.Epsilon && !allowedMoveDown) // Down
        {
            currentMovement.y = 0;
        }
        else if (currentMovement.x > float.Epsilon && !allowedMoveRight) // Right
        {
            currentMovement.x = 0;
        }
        else if (currentMovement.x < -float.Epsilon && !allowedMoveLeft) // Left
        {
            currentMovement.x = 0;
        }

        if (currentMovement.HasMovementAtAnyAxis())
            MoveObject(rb2d, currentMovement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb2d.velocity = new Vector2(0, 0);
            collision.rigidbody.velocity = new Vector2(0, 0);
        }
    }

    private Vector2 GetCurrentMovement()
    {
        var inputMupltiplier = GetMovementMultiplier();
        var xMovement = inputMupltiplier * Input.GetAxisRaw("Horizontal");
        var yMovement = inputMupltiplier * Input.GetAxisRaw("Vertical");

        return new Vector3
        {
            x = xMovement,
            y = yMovement,
            z = 0
        };
    }
}
