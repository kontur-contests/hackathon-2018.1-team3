using UnityEngine;

public abstract class MeleeBullet : MovingObject
{
	private const int TtlLimit = 2;
	private int ttl;

	private float _objectSpeed = 0.01f;

	protected abstract Rigidbody2D rb2d { get; }

	public abstract int Damage { get; }

	// Update is called once per frame
	void Update()
	{
		ttl++;
		MoveObject(rb2d, GetNewMovementByDirection());
		if (ttl >= TtlLimit)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Player"))
			Destroy(gameObject);
	}

	protected override float ObjectSpeed
	{
		get { return _objectSpeed; }
	}

	private Vector2 GetNewMovementByDirection()
	{
		var direction = PlayerAttributes.Direction;
		var movementMultiplier = GetMovementMultiplier();
		var x = 0f;
		var y = 0f;
		if (direction == Direction.Right)
			x = movementMultiplier;
		else if (direction == Direction.Left)
			x = -movementMultiplier;
		else if (direction == Direction.Top)
			y = movementMultiplier;
		else if (direction == Direction.Down)
			y = movementMultiplier;
		
		return new Vector2(x, y);
	}
}
