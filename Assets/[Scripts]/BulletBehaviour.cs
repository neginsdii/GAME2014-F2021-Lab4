using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Movement")]
    [Range(0.0f,0.5f)]
    public float Speed;
    public Bounds bulletBounds;
    public BulletDirection direction;
    private BulletManager bulletManager;
    private Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
        switch(direction)
		{
            case BulletDirection.UP:
                Velocity = new Vector3(0.0f, Speed, 0.0f);
                break;
            case BulletDirection.DOWN:
                Velocity = new Vector3(0.0f, -Speed, 0.0f);
                break;
		}

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

	private void Move()
	{

        transform.position += Velocity;
	}

    private void CheckBounds()
	{
        if (transform.position.y > bulletBounds.min)
        {
            bulletManager.ReturnBullet(this.gameObject);
        }
        //check bottom bounds
        if (transform.position.y< bulletBounds.max)
		{
            bulletManager.ReturnBullet(this.gameObject);
		}
	}
}

