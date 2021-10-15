using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;
    public int enemyBulletNumber;
    public int playerBulletNumber;
    private BulletFactory factory;
    // Start is called before the first frame update
    void Start()
    {
        enemyBulletPool = new Queue<GameObject>(); 
        playerBulletPool = new Queue<GameObject>();
        factory = GetComponent<BulletFactory>();
    //    buildBulletPool();
        
    }



    private void Addbullet(BulletType type = BulletType.ENEMY)
	{

        var temp = factory.createBullet(type);
        switch(type)
		{
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(temp);
                enemyBulletNumber++;
                break;
            case BulletType.PLAYER:
               playerBulletPool.Enqueue(temp);
                playerBulletNumber++;
                break;
        }
        

    }
    public GameObject getBullet(Vector2 position, BulletType type = BulletType.ENEMY)
    {
        GameObject temp = null;
        switch (type)
        {
            case BulletType.ENEMY:
                if (enemyBulletPool.Count < 1)
                {
                    Addbullet();

                }
                 temp = enemyBulletPool.Dequeue();
                temp.transform.position = position;
                temp.SetActive(true);
              
                break;
            case BulletType.PLAYER:
                if (playerBulletPool.Count < 1)
                {
                    Addbullet(BulletType.PLAYER);

                }
                 temp = playerBulletPool.Dequeue();
                temp.transform.position = position;
                temp.SetActive(true);
                break;
        }
        return temp;
    }

    public void ReturnBullet(GameObject reBullet,BulletType type = BulletType.ENEMY)
	{
        reBullet.SetActive(false);
        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(reBullet);
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(reBullet);
                break;
        }
	}
}
