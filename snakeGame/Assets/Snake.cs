using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments = new List<Transform>();

    public Transform SegmentPrefab;

    public int initialSize = 4;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }

    }
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i >0 ; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        
        transform.position = new Vector3(
                Mathf.Round(transform.position.x) + _direction.x,
                Mathf.Round(transform.position.y ) + _direction.y,
                0.0F);
    }
    private void Grow()
    {
        Transform segment = Instantiate(SegmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void ResetState()
    {
        for(int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);  
        }
        _segments.Clear();
        _segments.Add(transform);

        for(int i = 1; i < initialSize; i++)
        {
            _segments.Add(Instantiate(SegmentPrefab));
        }

        transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
