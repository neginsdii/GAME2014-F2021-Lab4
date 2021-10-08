using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("PlayerMovement")] 
    private Rigidbody2D rigidBody;
    [Range(0.0f,1.0f)]
    public float decay;
    public Bounds bounds;
    [Range(0.0f,100.0f)]
    public float horizontalForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

	private void Move()
	{
        var x = Input.GetAxisRaw("Horizontal");
        rigidBody.AddForce(new Vector2(x * horizontalForce, 0.0f));
        rigidBody.velocity *= (1.0f - decay);
	}

    private void CheckBounds()
	{
        //left bound
        if(transform.position.x<bounds.min)
		{
            transform.position = new Vector2(bounds.min, transform.position.y);
		}
        //right bound
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);

        }
    }
}
