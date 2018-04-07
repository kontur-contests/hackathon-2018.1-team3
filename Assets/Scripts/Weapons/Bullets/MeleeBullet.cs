using UnityEngine;

public abstract class MeleeBullet : MovingObject
{
	private const int TtlLimit = 2;
	private int ttl;

	private float _objectSpeed = 0.1f;

	protected abstract Rigidbody2D rb2d { get; }

	public abstract int Damage { get; }
	
	// Use this for initialization

	// Update is called once per frame
	void Update()
	{
		ttl++;
		var movementMultiplier = GetMovementMultiplier();
		MoveObject(rb2d, new Vector2(movementMultiplier, 0)); // TODO: сделать направление
		if (ttl >= TtlLimit)
		{
			Destroy(this);
		}
	}

	protected override float ObjectSpeed
	{
		get { return _objectSpeed; }
	}
}
