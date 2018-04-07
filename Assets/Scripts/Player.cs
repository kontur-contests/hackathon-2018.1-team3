using Extensions;
using UnityEngine;
using Weapons;

public class Player : MovingObject
{
    private Rigidbody2D rb2d;
    private CircleCollider2D c2d;
    private PlayerAttributes playerAttributes;
    private bool allowedMoveUp;
    private bool allowedMoveDown;
    private bool allowedMoveLeft;
    private bool allowedMoveRight;
    private Weapon playerWeapon;
    public GameObject Bullet;
    private int direction;

    protected override float ObjectSpeed
    {
        get { return 5.0f; }
    }

    // Use this for initialization
	void Start ()
	{
	    rb2d = GetComponent<Rigidbody2D>();
	    c2d = GetComponent<CircleCollider2D>();
        allowedMoveUp = true;
        allowedMoveDown = true;
        allowedMoveLeft = true;
        allowedMoveRight = true;
	    playerAttributes = gameObject.AddComponent<PlayerAttributes>();
	    playerWeapon = playerAttributes.CurrentPlayerWeapon
	        ? playerAttributes.CurrentPlayerWeapon
	        : gameObject.AddComponent<Katana>();
	}
	
	// Update is called once per frame
    void Update()
    {
        AttemptToMove();
        AttemptToAttack();
    }

    private void AttemptToMove()
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

    private void AttemptToAttack()
    {
        var fire = Input.GetKeyUp("space");
        if (fire)
            Instantiate(Bullet, rb2d.position + new Vector2(c2d.radius + 1f, 0), Quaternion.identity);
    }
}
