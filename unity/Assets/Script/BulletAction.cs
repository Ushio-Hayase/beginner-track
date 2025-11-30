using System;
using UnityEngine;

public class BulletAction : MonoBehaviour{

    Rigidbody2D rigid;
    public float speed;
    public float damage; 
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        var vec = new Vector2((float)Math.Cos(rigid.rotation+90), (float)Math.Sin(rigid.rotation+90));
        rigid.linearVelocity = vec * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!((transform.position.x >= GameManager.instance.map_top_left_pos.x && transform.position.y >= GameManager.instance.map_top_left_pos.y) &&
             (transform.position.x <= GameManager.instance.map_bottom_right_pos.x &&
              transform.position.y <= GameManager.instance.map_bottom_right_pos.y))) Destroy(this);
    }
    
}
