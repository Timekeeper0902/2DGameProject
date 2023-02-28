using System;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

namespace Timekeeper._Scripts.Enemies.EnemySpecific.Bat
{
    public class Bat : FlyEntity
    {
        public bool CanSetVelocity { get; set; }

        public Vector2 CurrentVelocity { get; private set; }

        public float knockbackDistance;

        private Vector2 workspace;
    
        private bool isKnockbackActive;
        private float knockbackStartTime;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            chasePoint = idlePoints[Random.Range(0, idlePoints.Length)];
        }

        private void Update()
        {
            if (CheckPlayer())
            {
                ChasePlayer();
            }
            else
            {
                ChaseToPoint();
            }
        }

        /// <summary>
        /// 向随机点移动
        /// </summary>
        public void ChaseToPoint()
        {
            if (transform.position != chasePoint.position)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, chasePoint.position,
                    Time.deltaTime * moveSpeed);
            }

            if (Vector3.Distance(transform.position, chasePoint.position) <= 0.05f)
            {
                chasePoint = idlePoints[Random.Range(0, idlePoints.Length)];
            }
        }

        /// <summary>
        /// 向玩家移动
        /// </summary>
        public void ChasePlayer()
        {
            transform.position = Vector3.MoveTowards(this.transform.position,player.transform.position,
                Time.deltaTime * moveSpeed * 1.2f);
        }
        
        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="amount"></param>
        public override void Damage(float amount)
        {
            base.Damage(amount);
            
            Debug.Log(amount + " Damage taken");
            //FloatPoint显示
            GameObject gb = Instantiate(floatPoint,transform.position,Quaternion.identity);
            gb.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString(); 

            Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            if (CheckFacing())
            {
                transform.position = new Vector3(-knockbackDistance + transform.position.x,transform.position.y,transform.position.z) ;
                print(this.transform.position);
                positionX = transform.position.x;
            }
            else
            {
                transform.position = new Vector3(knockbackDistance + transform.position.x,transform.position.y,transform.position.z) ;
                print(this.transform.position);
                positionX = transform.position.x;
            }
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();
        }

        public override bool CheckFacing()
        {
            return base.CheckFacing();
        }
    }
}