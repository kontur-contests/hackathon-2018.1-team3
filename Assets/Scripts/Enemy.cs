using Extensions;
using UnityEngine;

public class Enemy : MovingObject
{
	private float _objectSpeed = 1.0f;
	private Rigidbody2D rb2d;
    private bool followActive;
	public int HP = 100;

    void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
        followActive = true;
    }

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player") && followActive)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            followActive = false;
        }
	    if (collision.gameObject.CompareTag("Bullet"))
	    {
		    HP -= 20;
		    Debug.Log(HP);
	    }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            followActive = true;
        }
    }

    protected override float ObjectSpeed
	{
		get { return _objectSpeed; }
	}
}
