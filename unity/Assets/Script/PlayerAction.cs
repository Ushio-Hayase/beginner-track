using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    
    private float _h;
    private float _v;

    private Vector3 _direction;

    private GameObject _collisionObj;
    
    private Rigidbody2D _rigid;

    private bool _isHorizonMove;

    public GameManager gameManager;
    public Animator _anim;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isAction)
        {
            // Move
            _h = Input.GetAxisRaw("Horizontal");
            _v = Input.GetAxisRaw("Vertical");

            // Check button up & down
            bool hDown = Input.GetButtonDown("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");

            // Check horizontal move
            if (hDown) _isHorizonMove = true;
            else if (vDown) _isHorizonMove = false;

            //Animation
            if (_isHorizonMove)
            {
                _anim.SetInteger("hAxisRaw", (int)_h);
            }
            else
                _anim.SetInteger("vAxisRaw", (int)_v);

            //Direction
            if (!_isHorizonMove && _v > 0) _direction = Vector3.up;
            else if (!_isHorizonMove && _v < 0) _direction = Vector3.down;
            else if (_isHorizonMove && _h > 0) _direction = Vector3.right;
            else if (_isHorizonMove && _h < 0) _direction = Vector3.left;
        }
        
        if(Input.GetButtonDown("Jump")&&_collisionObj) gameManager.Action(_collisionObj);
    }

    void FixedUpdate()
    {
        // Move
        Vector2 moveVec = _isHorizonMove ? new Vector2(_h, 0) : new Vector2(0, _v);
        _rigid.linearVelocity = moveVec * speed;
        
        // Ray
        Debug.DrawRay(_rigid.position, _direction*0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(_rigid.position, _direction, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider) _collisionObj = rayHit.collider.gameObject;
        else _collisionObj = null;
    }
}
