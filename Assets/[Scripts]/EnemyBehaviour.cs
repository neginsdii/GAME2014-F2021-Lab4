using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")]
    public Bounds movementBounds;
    public Bounds startRange;
   
    private float startingPoint;
    private float randomSpeed;
    private BulletManager bulletManager;
    [Header("Bullets")]
    public Transform bulletSpawn;
    public int frameDelay;

    void Start()
    {
        randomSpeed = Random.Range(movementBounds.min, movementBounds.max);
        startingPoint = Random.Range(startRange.min, startRange.max);
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startingPoint, transform.position.y);
    }

	private void FixedUpdate()
	{
		if(Time.frameCount % frameDelay ==0)
		{
            bulletManager.getBullet(bulletSpawn.position);
		}
	}
}
