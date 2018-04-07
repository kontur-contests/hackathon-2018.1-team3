public abstract class MeleeBullet : MovingObject
{
	private const int TtlLimit = 2;
	private int ttl;

	private float _objectSpeed = 0.1f;

	public abstract int Damage { get; }
	
	// Use this for initialization

	// Update is called once per frame
	void Update ()
	{
		ttl++;
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
