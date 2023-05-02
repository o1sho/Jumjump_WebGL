using UnityEngine;
using UnityEngine.Events;

public class OnCollisionColor : MonoBehaviour
{
    public UnityEvent Right;
    public UnityEvent Wrong;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        RandomColor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_spriteRenderer.color == Color.blue && collision.gameObject.tag == "BlueP")
        {
            Right.Invoke();
            _spriteRenderer.color = Color.red;
            Debug.Log("Синий");
        } else if (_spriteRenderer.color == Color.red && collision.gameObject.tag == "RedP")
        {
            Right.Invoke();
            _spriteRenderer.color = Color.blue;
            Debug.Log("Красный");
        } 
        else if (_spriteRenderer.color == Color.blue && collision.gameObject.tag == "RedP") Wrong.Invoke();
        else if (_spriteRenderer.color == Color.red && collision.gameObject.tag == "BlueP") Wrong.Invoke();
    }

    private void RandomColor()
    {
        var colors = new[] {
        Color.blue,
        Color.red};

        int randomColor = Random.Range(0, colors.Length);
        _spriteRenderer.color = colors[randomColor];
    }
}
