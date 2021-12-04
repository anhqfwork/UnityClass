using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text enemyScoreText;

    [SerializeField] private Vector3 playerInitialPosition;
    [SerializeField] private Vector3 enemyInitialPosition;
    [SerializeField] private Vector3 ballInitialPosition;
    [SerializeField] private List<Vector2> ballInitialVelocity;

    private int playerScore;
    private int enemyScore;

    [SerializeField] private Canvas scoreCanvas;
    [SerializeField] private Canvas endCanvas;
    [SerializeField] private Canvas homeCanvas;


    [SerializeField] private Text resultText; 
    [SerializeField] private Button newGameBut, quitGameBut, playGame;

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
        player.SetActive(false);
        enemy.SetActive(false);
        ball.SetActive(false);
        endCanvas.enabled = false;
        scoreCanvas.enabled = false;
        homeCanvas.enabled = true;
        newGameBut.onClick.AddListener(NewGame);
        quitGameBut.onClick.AddListener(quitGame);
        playGame.onClick.AddListener(NewGame);
    }

    void NewGame()
    {
        player.SetActive(true);
        enemy.SetActive(true);
        ball.SetActive(true);
        playerScore = 0;
        enemyScore = 0;
        endCanvas.enabled = false;
        scoreCanvas.enabled = true;
        homeCanvas.enabled = false;
        playerScoreText.text = $"{playerScore}";
        enemyScoreText.text = $"{enemyScore}";
        StartCoroutine(NewTurn());
    }

    private IEnumerator NewTurn()
    {
        ball.transform.position = ballInitialPosition;
        player.transform.position = playerInitialPosition;
        enemy.transform.position = enemyInitialPosition;
        ball.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        yield return new WaitForSeconds(2);
        ball.transform.GetComponent<Rigidbody2D>().velocity = ballInitialVelocity[Random.Range(0, ballInitialVelocity.Count)];
        ball.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public void changeScore(bool DoesPlayerWin)
    {
        if (DoesPlayerWin)
        {
            playerScore++;
            playerScoreText.text = $"{playerScore}";
        } else
        {
            enemyScore++;
            enemyScoreText.text = $"{enemyScore}";
        }

        if (playerScore == 5)
        {
            scoreCanvas.enabled = false;
            endCanvas.enabled = true;
            resultText.text = "You Win!";
            ball.SetActive(false);
            enemy.SetActive(false);
            ball.SetActive(false);
        } else if (enemyScore == 5)
        {
            scoreCanvas.enabled = false;
            endCanvas.enabled = true;
            resultText.text = "You Lose!";
            player.SetActive(false);
            enemy.SetActive(false);
            ball.SetActive(false);
        } else
        {
            StartCoroutine(NewTurn());
        }
    }

    void quitGame()
    {
        Debug.Log("Quit Game");
        endCanvas.enabled = false;
        homeCanvas.enabled = true;
    }
}
