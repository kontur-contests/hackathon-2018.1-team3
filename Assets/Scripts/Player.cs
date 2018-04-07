using Assets.Scripts.Extensions;
using Assets.Scripts.Models;
using UnityEngine;

public class Player : MovingObject
{

    protected override float ObjectSpeed
    {
        get { return 10.0f; }
    }

    // Use this for initialization
	void Start ()
	{
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
            MoveObject(currentMovement);
    }

    private CurrentMovement GetCurrentMovement()
    {
        var xMovement = ObjectSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        var yMovement = ObjectSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");

        return new CurrentMovement
        {
            XAxisMovement = xMovement,
            YAxisMovement = yMovement
        };
    }
}
