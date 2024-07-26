using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLife : MonoBehaviour
{
    public float lifeTime = 10;
    public GameObject deadSound;
    public GameObject deadParticle;
    
    private int type;
    private float curT = 0;
    private int health;
    private bool isAlive = false;
    private CollectScore scoreE;

    public void setHP(int hp, int _type)
    {
        health = hp;
        type = _type;
    }

    public void setScoreE(CollectScore _scoreE)
    {
        scoreE = _scoreE;
    }

    public void collisionBullet(int damage)
    {
        health -= damage;
        if(health <= 0 && !isAlive)
        {
            isAlive = true;

            // �ı� ����Ʈ
            Instantiate(deadParticle, transform.position, Quaternion.identity);

            // �ı� �Ҹ�
            Instantiate(deadSound, transform.position, Quaternion.identity);

            // ������ �÷��� ��.
            scoreE.upScore(type * 300);

            Destroy(gameObject);
        }
    }

    void Update()
    {
        curT += Time.deltaTime;
        if (curT > lifeTime)
        {
            Destroy(gameObject);
        }

    }
}
