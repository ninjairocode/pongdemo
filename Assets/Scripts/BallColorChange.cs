using UnityEngine;

public class BallColorChanger : MonoBehaviour
{
    private SpriteRenderer _ballSpriteRenderer;

    void Start()
    {
        
        _ballSpriteRenderer = GetComponent<SpriteRenderer>();

        if (_ballSpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer não encontrado no objeto da bola!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            ChangeBallColor();
        }
    }

    private void ChangeBallColor()
    {
        // Gera uma cor aleatória
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        _ballSpriteRenderer.color = randomColor;
        Debug.Log("Cor da bola alterada para: " + randomColor);
    }
}

