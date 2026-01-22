using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform[] _points;
    
    private SpriteRenderer _spriteRenderer;

    private int i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, _points[i].position) < 0.25f)
        {
            i++;
            if (i == _points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _points[i].position, _speed * Time.deltaTime);
        
        _spriteRenderer.flipX = (transform.position.x - _points[i].position.x) < 0f;
    }
}
