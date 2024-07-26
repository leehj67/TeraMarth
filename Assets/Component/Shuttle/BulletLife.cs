using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float lifeTime = 10;
    public GameObject collisionParticle;

    private int Damage = 6;
    private float curT = 0;
    private bool isAttack = false;
    private Color c;
    private GameObject p;

    void OnDestroy()
    {
        if (p != null)
        {
            Destroy(p);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Target") && !isAttack)
        {
            // Ÿ�� ����Ʈ
            p = Instantiate(collisionParticle, transform.position - GetComponent<Rigidbody>().velocity.normalized * 15, Quaternion.identity);
            p.transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);

            // �Ѿ� ����
            collision.gameObject.GetComponent<RockLife>().collisionBullet(Damage);
            c = GetComponent<Renderer>().material.color;
            c.a = 0.0f;
            GetComponent<Renderer>().material.color = c;

            // Ÿ�� ����
            transform.Find("AttackSound").GetComponent<AudioSource>().Play();

            lifeTime = curT + 1.0f;
            isAttack = true;
        }
    }

    void Update()
    {
        curT += Time.deltaTime;

        if(curT > lifeTime)
        {
            Destroy(gameObject);
        }
        
    }
}
