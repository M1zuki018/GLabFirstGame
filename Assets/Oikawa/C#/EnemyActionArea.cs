using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof (BoxCollider2D))]
public class EnemyActionArea : MonoBehaviour
{
    [Header("�m�F�ł���Enemy�B")]
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform target = collision.transform;
        if (target.CompareTag("Enemy"))
        {
            Debug.Log("�G�������o�����B");
            for (int i = 0; i < _enemies.Length; i++)
            {
                if (target == _enemiesTra[i])
                {
                    _enemies[i].enabled = true;
                    return;
                }
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform target = collision.transform;
        if (target.CompareTag("Enemy"))
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                if (target == _enemiesTra[i])
                {
                    _enemies[i].enabled = false;
                    Debug.Log("�G���~�߂�");
                    return;
                }
            }

        }
    }
}