using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
  
    private Rigidbody2D rb;
    public float speed;
    private GameObject ball;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f);
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        
    }
}
