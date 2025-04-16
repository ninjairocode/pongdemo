using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);

    public GameManager gameManager;

    public float speedUp = 1.1f;

    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D não encontrado no objeto BallController!");
        }
    }

    public void ResetBall()
    {
        
        transform.position = Vector3.zero;

        if (_rb != null)
        {
            _rb.velocity = startingVelocity;
        }
        else
        {
            Debug.LogError("Rigidbody2D não está inicializado!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = _rb.velocity;
            newVelocity.y = -newVelocity.y;
            _rb.velocity = newVelocity;
        }

        
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _rb.velocity = new Vector2(-_rb.velocity.x, _rb.velocity.y);
            _rb.velocity *= speedUp;
        }

        
        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            if (gameManager != null)
            {
                gameManager.ScorePlayer();
                ResetBall();
            }
            else
            {
                Debug.LogError("GameManager não está atribuído!");
            }
        }

        
        else if (collision.gameObject.CompareTag("WallPlayer"))
        {
            if (gameManager != null)
            {
                gameManager.ScoreEnemy();
                ResetBall();
            }
            else
            {
                Debug.LogError("GameManager não está atribuído!");
            }
        }
    }
}
