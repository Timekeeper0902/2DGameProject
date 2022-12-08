using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //private AttackDetails attackDetails;

    private float _speed;
    private float _travelDistance;
    private float _xStartPos;
    private float _rangeDamage;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float damageRadius;

    private Rigidbody2D _rb;

    private bool _isGravityOn;
    private bool _hasHitGround;

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private Transform damagePosition;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.gravityScale = 0.0f;
        _rb.velocity = transform.right * _speed;

        _isGravityOn = false;

        _xStartPos = transform.position.x;
    }

    private void Update()
    {
        if (!_hasHitGround)
        {
            //attackDetails.position = transform.position;

            if (_isGravityOn)
            {
                float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!_hasHitGround)
        {
            Collider2D[] damageHits = Physics2D.OverlapCircleAll(damagePosition.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

            foreach (Collider2D collider in damageHits)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();

                if (damageable != null) {
                    damageable.Damage(_rangeDamage);
                }
                Destroy(gameObject);
            }

            if (groundHit)
            {
                _hasHitGround = true;
                _rb.gravityScale = 0f;
                _rb.velocity = Vector2.zero;
            }


            if (Mathf.Abs(_xStartPos - transform.position.x) >= _travelDistance && !_isGravityOn)
            {
                _isGravityOn = true;
                _rb.gravityScale = gravity;
            }
        }        
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        this._speed = speed;
        this._travelDistance = travelDistance;
        _rangeDamage = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
}
