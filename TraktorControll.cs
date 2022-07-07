using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraktorControll : SimpleInput
{
    public float _speedMove;
    public float _speedRotate;

    [SerializeField] private GameObject _traktorWheels;
    [SerializeField] private GameObject _harvestWheels;

    private Animator _traktorAnim;
    private Animator _harvestAnim;

    private float _verticalDirection;
    private float _horizontalDirection;

    private Rigidbody _rb;
    private Vector3 _rotateStep;

    private void Start()
    {
        _traktorAnim = _traktorWheels.GetComponent<Animator>();
        _harvestAnim = _harvestWheels.GetComponent<Animator>();

        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _verticalDirection = SimpleInput.GetAxis("Vertical");
        _horizontalDirection = SimpleInput.GetAxis("Horizontal");

        if(_verticalDirection != 0 || _horizontalDirection != 0)
        {
            Vector3 direction = new Vector3(_horizontalDirection * _speedMove, 0, _verticalDirection * _speedMove);

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, rotation, _speedRotate * Time.fixedDeltaTime);
            _rb.velocity = direction;

            if(_traktorWheels.activeSelf)
            {
                _traktorAnim.SetTrigger("Move");
            }
            if(_harvestWheels.activeSelf)
            {
                _harvestAnim.SetTrigger("Move");
            }
            
            
        }
        else
        {
            FreezPosition();
        }
    }

    private void FreezPosition()
    {
        _rb.angularVelocity = Vector3.zero;
        _rb.velocity = Vector3.zero;

        if(_traktorWheels.activeSelf)
        {
            _traktorAnim.SetTrigger("Idle");
        }
        if(_harvestWheels.activeSelf)
        {
            _harvestAnim.SetTrigger("Idle");
        }
        
    }
}
