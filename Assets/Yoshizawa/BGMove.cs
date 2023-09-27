using UnityEngine;

// 日本語対応
public class BGMove : MonoBehaviour
{
    public float MoveSpeed { get; set; } = 0.4f;
    public float LifeTime { get; set; } = 5.0f;

    private Vector3 _move = Vector3.zero;

    private void Start()
    {
        _move = Vector3.back * MoveSpeed;
        Destroy(gameObject, LifeTime);
    }

    private void FixedUpdate()
    {
        transform.position += _move;
    }
}