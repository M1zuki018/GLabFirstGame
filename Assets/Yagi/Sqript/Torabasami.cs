using UnityEngine;
using System.Collections;



public class Torabasami : MonoBehaviour
{
    [SerializeField, Header("���������")] GameObject _meat;
    [SerializeField, Header("�����g���o�T�~�̃C���X�g")] Sprite _closedTorabasami;
    SpriteRenderer _torabasamiSprite;
    [SerializeField] float _stopTime;
    PlayerController _controller;
    bool _isTrap;
    float _timer;
    void Start()
    {
        _controller = GameObject.Find("Player").GetComponent<PlayerController>();
        _torabasamiSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isTrap)
        {
            _torabasamiSprite.sprite = _closedTorabasami;
            _controller.transform.position = new Vector2(transform.position.x, _controller.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TrapTime(_stopTime));
            _controller.FluctuationLife(-1);
            _controller.StopAction(_stopTime);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if (_meat)
            {
                Instantiate(_meat);
            }
        }

        IEnumerator TrapTime(float time)
        {
            _isTrap = true;
            yield return new WaitForSeconds(time);
            _isTrap = false;
        }
    }
}
