using Assets.Scripts.Extensions;
using Assets.Scripts.Models;
using UnityEngine;

public class Player : MovingObject
{

    public int health=100;
    public int maxHealth;
    //public string weapon1;
    //public string weapon2;
    public int strength=1;
    public int agility=1;
    public int endurance=1;

    protected override float ObjectSpeed
    {
        get { return 10.0f; }
    }

    // Use this for initialization
	void Start ()
	{
        maxHealth = 50 + 50 * endurance;
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
