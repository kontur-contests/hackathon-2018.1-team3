using UnityEngine;

public class Enemy : MovingObject
{
	private float _objectSpeed = 1.0f;
	private Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		var enemyPosition = other.transform.position;
		var necessaryMovement = CalculateNecessaryMovementValues(enemyPosition);
		MoveObject(rb2d, necessaryMovement);
	}

	private Vector3 CalculateNecessaryMovementValues(Vector3 otherMovement)
	{
		var currentPosition = transform.position;
		var multiplier = GetMovementMultiplier();
		return multiplier * (otherMovement - currentPosition);
	}

	protected override float ObjectSpeed
	{
		get { return _objectSpeed; }
	}
}
