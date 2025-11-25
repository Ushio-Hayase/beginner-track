using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;

    private float x_;
    private float y_;

    private GameObject collisionObj_;
    
    private Rigidbody2D rigid_;

    public GameManager gameManager_;
    public Animator anim_;

    private void Awake()
    {
        rigid_ = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!gameManager_.isAction)
        {
            // Move
            x_ = Input.GetAxis("Horizontal");
            y_ = Input.GetAxis("Vertical");
        }
    }

    void FixedUpdate()
    {
        // Move
        Vector2 moveVec = new Vector2(x_, y_);
        
        rigid_.linearVelocity = moveVec *speed;

        anim_.SetInteger("hAxisRaw", (int)(x_*10));
        anim_.SetInteger("vAxisRaw", (int)(y_*10));
        
    }

}
