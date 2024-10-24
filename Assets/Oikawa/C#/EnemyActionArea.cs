using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof (BoxCollider2D))]
public class EnemyActionArea : MonoBehaviour
{
    [Header("確認できたEnemy達")]
    [SerializeField] Enemy[] _enemies;
    Transform[] _enemiesTra;
    void Start()
    {
        _enemies = GameObject.FindObjectsOfType<Enemy>();
        _enemiesTra = new Transform[_enemies.Length];
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].enabled = false;
            _enemiesTra[i] = _enemies[i].transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D col) => EnemyFunc(col, true, "敵が動き出した");
    private void OnTriggerExit2D(Collider2D col) => EnemyFunc(col, false, "敵を止めた");
    void EnemyFunc(Collider2D col,bool enabled,string logStr)
    {
        Transform target = col.transform;
        if (target.CompareTag("Enemy"))
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                if (_enemies[i] == null)
                    continue;
                if (_enemiesTra[i] == null)
                    continue;
                if (target == _enemiesTra[i])
                {
                    _enemies[i].enabled = enabled;
                    //Debug.Log(logStr);
                    return;
                }
            }

        }
    }
}
