using System;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public float speed;
    public float hp;
    public int damage;
    private GameObject player;
    private Rigidbody2D rigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var delta_v = player.transform.position - transform.position;

        rigid.linearVelocity = delta_v.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp -= other.gameObject.GetComponent<BulletAction>().damage;
            Destroy(other.gameObject);
            if (hp <= 0) Destroy(this);
            
        }
    }
}
