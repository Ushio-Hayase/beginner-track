using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    
    private float _h;
    private float _v;

    private Rigidbody2D _rigid;

    private bool _isHorizonMove;

    public GameObject gameManager;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown || vUp) _isHorizonMove = true;
        else if (vDown || hUp) _isHorizonMove = false;
    }

    void FixedUpdate()
    {
        Vector2 moveVec = _isHorizonMove ? new Vector2(_h, 0) : new Vector2(0, _v);
        _rigid.linearVelocity = moveVec * speed;
    }
}
