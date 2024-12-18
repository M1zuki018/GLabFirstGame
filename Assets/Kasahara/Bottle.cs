using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : ItemBase
{
    [SerializeField, Header("接地判定の大きさ")] Vector2 _size;
    [SerializeField, Header("接地判定の角度")] float _angle;
    bool _effected;
    Rigidbody2D _rb;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 1, 0.5f);
        Gizmos.DrawWireSphere(transform.position, EffectRange);
        Gizmos.DrawWireCube(transform.position, _size);
    }
    public override void Activate()
    {
        if (IsThrowing)
        {
            if (!Landing)
            {
                var hit = Physics2D.OverlapBoxAll(transform.position, _size, _angle);
                foreach (var obj in hit)
                {
                    if (obj.gameObject.CompareTag("Ground"))
                    {
                        Landing = true;
                        //地面についたらコライダーを復活
                        GetComponent<Collider2D>().enabled = true;
                        AudioManager.Instance.PlaySE("crack");
                    }
                }
            }
            else
            {
                if (!_effected)
                {
                    var hit = Physics2D.OverlapCircleAll(transform.position, EffectRange);
                    _rb = GetComponent<Rigidbody2D>();
                    foreach (var obj in hit)
                    {
                        if (obj.CompareTag("Enemy"))
                        {
                            //敵が逃げる処理
                            obj.gameObject.GetComponent<Enemy>().ReactionBottle(transform.position, ActivatetTime);
                        }
                    }
                    Destroy(gameObject, ActivatetTime);
                    _effected = true;
                }
                if(_effected && _rb.velocity.y == 0)
                {
                    _rb.velocity = Vector2.zero;
                    _rb.bodyType = RigidbodyType2D.Kinematic;
                    gameObject.GetComponent<Collider2D>().enabled = false;
                }
            }

        }
    }
}
