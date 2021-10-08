using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public int bulletNumber;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        buildBulletPool();
    }

   
    private void buildBulletPool()
	{
        for (int i = 0; i < bulletNumber; i++)
        {
            Addbullet();
        }
	}

    private void Addbullet()
	{
        
            var temp = Instantiate(bulletPrefab);
            temp.SetActive(false);
            temp.transform.parent = transform;
            bulletPool.Enqueue(temp);

       
    }
    public GameObject getBullet(Vector2 position)
	{
        if (bulletPool.Count < 1)
        {
            Addbullet();
            bulletNumber++;
        }
        var temp = bulletPool.Dequeue();
        temp.transform.position = position;
        temp.SetActive(true);
        return temp;
	}

    public void ReturnBullet(GameObject reBullet)
	{
        reBullet.SetActive(false);
        bulletPool.Enqueue(reBullet);
	}
}
