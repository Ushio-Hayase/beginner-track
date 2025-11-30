using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public int hp;

    private float x_;
    private float y_;
    
    private Rigidbody2D rigid_;
    private float shoot_angle = 0;
    
    public Animator anim_;
    
    private float live_time = 0;
    private float prev_time = 0;

    public GameObject bullet;

    private void Awake()
    {
        rigid_ = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
            // Move
            x_ = Input.GetAxis("Horizontal");
            y_ = Input.GetAxis("Vertical");
            
            
            if (Input.GetKey(KeyCode.Space)&& prev_time > 0.2)
            {
            
                var pos = new Vector2(transform.position.x + (float)Math.Cos(shoot_angle), transform.position.y + (float)Math.Sin(shoot_angle));

                Quaternion targetRotation = Quaternion.Euler(0, 0, shoot_angle-90);
                Instantiate(bullet, pos, targetRotation);
            
                shoot_angle += 45;
                shoot_angle %= 360;
            
                prev_time = 0;
            }
        
    }
    
    void FixedUpdate()
    {
        // Move
        Vector2 moveVec = new Vector2(x_, y_);

        if (Input.GetKey(KeyCode.LeftShift)) moveVec *= 1.5f;
        
        rigid_.linearVelocity = moveVec *speed;

        anim_.SetInteger("hAxisRaw", (int)(x_*10));
        anim_.SetInteger("vAxisRaw", (int)(y_*10));

        live_time += Time.fixedDeltaTime;



        prev_time += Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            hp -= other.gameObject.GetComponent<EnemyAction>().damage;
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                GameManager.instance.score = (int)live_time;
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
            
    }
}
