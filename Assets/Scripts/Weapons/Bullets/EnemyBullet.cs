using UnityEngine;

public class EnemyBullet : MeleeBullet
{
	private int _damage = 20;
	private Rigidbody2D _rb2D;

	// Update is called once per frame
	protected override Rigidbody2D rb2d
	{
		get { return _rb2D; }
	}

	public override int Damage
	{
		get { return _damage; }
	}

	void Start()
	{
		_rb2D = GetComponent<Rigidbody2D>();
	}
}
