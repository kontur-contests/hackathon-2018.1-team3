using Extensions;
using UnityEngine;

public class Player : MovingObject
{
    private Rigidbody2D rb2d;
    
    protected override float ObjectSpeed
    {
        get { return 10.0f; }
    }

    // Use this for initialization
	void Start ()
	{
	    rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        AttemptToMove();
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
