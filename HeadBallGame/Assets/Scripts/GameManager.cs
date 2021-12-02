using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMesh scoreText;
    private int playerScore;
    private int enemyScore;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeScore(bool isPlayerWin)
    {
        if (isPlayerWin)
        {
            playerScore++;
            StartCoroutine(NewTurnCoroutine(false));
        } else
        {
            enemyScore++;
            StartCoroutine(NewTurnCoroutine(true));
        }
        scoreText.text = $"{playerScore} - {enemyScore}";
    }

    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private Vector2 ballPositionAtPlayerSide;
    [SerializeField] private Vector2 ballPositionAtEnemySide;

    private IEnumerator NewTurnCoroutine(bool IsPlayerSide)
    {
        ball.velocity = Vector2.zero;
        ball.bodyType = RigidbodyType2D.Kinematic;
        if (IsPlayerSide)
        {
            ball.transform.position = ballPositionAtPlayerSide;
        }
        else
        {
            ball.transform.position = ballPositionAtEnemySide;
        }
        yield return new WaitForSeconds(2);
        ball.bodyType = RigidbodyType2D.Dynamic;
    }
}
