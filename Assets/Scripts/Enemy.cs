using Extensions;
using UnityEngine;

public class Enemy : MovingObject
{
	private float _objectSpeed = 1.0f;
	private Rigidbody2D rb2d;
	private CircleCollider2D c2d;
    public bool followActive;
	public bool attack;
	private float timeBeforeNextShoot;
	private float collateralDamageTimer;
	private Direction direction;
	public int HP = 100;
	public GameObject Bullet;

    void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		c2d = GetComponent<CircleCollider2D>();
        followActive = true;
    }

	void Update()
	{
		AttemptToAttack();
		AttemptToAddCollateralDamage();

        if (followActive)
        {
            var center = transform.position;
            var playerCenter = GameObject.Find("Player").transform.position;
            
            var necessaryMovement = CalculateNecessaryMovementValues(playerCenter);
            direction = GetCurrentDirection(necessaryMovement);
            MoveObject(rb2d, necessaryMovement);

            attack = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            followActive = false;
        }
	    else if (collision.gameObject.CompareTag("KatanaBullet"))
	    {
		    HP -= 20;
		    if (HP <= 0)
			    Destroy(gameObject);
	    }
	    else if (collision.gameObject.CompareTag("GuitarBullet"))
	    {
		    HP -= 30;
		    if (HP <= 0)
			    Destroy(gameObject);
	    }
	    else if (collision.gameObject.CompareTag("ClubBullet"))
	    {
		    HP -= 20;
		    collateralDamageTimer = Time.deltaTime * 5;
		    if (HP <= 0)
			    Destroy(gameObject);
	    }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            followActive = true;
	        attack = false;
        }
    }
	
	private void AttemptToAttack()
	{
		if (timeBeforeNextShoot > float.Epsilon)
		{
			timeBeforeNextShoot -= Time.deltaTime;
			return;
		}

		if (!attack)
			return;
		
		Instantiate(Bullet, rb2d.position + GetBulletInstantionPositionByDirection(), Quaternion.identity);
		timeBeforeNextShoot = Time.deltaTime * 10;
	}

	private void AttemptToAddCollateralDamage()
	{
		if (collateralDamageTimer > float.Epsilon)
		{
			collateralDamageTimer -= Time.deltaTime;
			HP -= 5;
		}
	}

	private Vector2 GetBulletInstantionPositionByDirection()
	{
		var x = 0f;
		var y = 0f;
		if (direction == Direction.Right)
			x = c2d.radius + 1f;
		else if (direction == Direction.Left)
			x = -c2d.radius - 1f;
		else if (direction == Direction.Top)
			y = c2d.radius + 1f;
		else if (direction == Direction.Down)
			y = -c2d.radius - 1f;
		
		return new Vector2(x, y);
	}

	private Direction GetCurrentDirection(Vector3 currentMovement)
	{
		if (currentMovement.x >= float.Epsilon)
			return Direction.Right;
		if (currentMovement.x < -float.Epsilon)
			return Direction.Left;
        
		return currentMovement.y >= float.Epsilon
			? Direction.Top
			: Direction.Down;
	}

	protected override float ObjectSpeed
	{
		get { return _objectSpeed; }
	}
}
