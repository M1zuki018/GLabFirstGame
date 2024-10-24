using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField, Header("RedImageを入れる")] GameObject _redObject;
    GameManager _gameManager;
    public static Vector2 position;
    Checkpoint _point;


    void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _point = FindAnyObjectByType<Checkpoint>();      
    }

    void Update()
    {
        IsGameOver();
    }

    private void IsGameOver()
    {
        if (_gameManager.State == GameManager.GameState.GameOver)
        {
            _redObject.SetActive(true);
            if (_point != null)
            {
                Debug.Log("通過");
                position = _point._checkpoint;
            }
        }
    }
}
