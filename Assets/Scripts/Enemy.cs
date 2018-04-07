using Extensions;
using UnityEngine;

public class Enemy : MovingObject
{
	private float _objectSpeed = 1.0f;
	private Rigidbody2D rb2d;
	private Collider2D c2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		c2d = GetComponent<Collider2D>();
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			var center = transform.position;
			var otherCenter = other.transform.position;
			
			if ((center - otherCenter).Length() <= other.bounds.extents.Length() + 0.2)
				rb2d.velocity = new Vector2(0, 0);
			else
			{
				var necessaryMovement = CalculateNecessaryMovementValues(otherCenter);
				MoveObject(rb2d, necessaryMovement);
			}
		}
	}
	
	protected override float ObjectSpeed
	{
		get { return _objectSpeed; }
	}
}
