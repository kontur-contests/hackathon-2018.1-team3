using Extensions;
using UnityEngine;

public class Player : MovingObject
{
    private Rigidbody2D rb2d;
    private Collider2D c2d;
    
    protected override float ObjectSpeed
    {
        get { return 5.0f; }
    }

    // Use this for initialization
	void Start ()
	{
	    rb2d = GetComponent<Rigidbody2D>();
	    c2d = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        AttemptToMove();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var center = transform.position;
            var otherCenter = other.transform.position;
            if ((center - otherCenter).Length() <= c2d.bounds.extents.Length() + 0.2)
                rb2d.velocity = new Vector2(0, 0);

            else
            {
                var necessaryMovement = CalculateNecessaryMovementValues(otherCenter);
                MoveObject(rb2d, necessaryMovement);
            }
        }
    }

    private void AttemptToMove()
    {
        var currentMovement = GetCurrentMovement();
        if (currentMovement.HasMovementAtAnyAxis())
            MoveObject(rb2d, currentMovement);
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
