public class KatanaBullet : MeleeBullet
{
	private int _damage = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override int Damage
	{
		get { return _damage; }
	}

	void Update () {
		
	}
}
