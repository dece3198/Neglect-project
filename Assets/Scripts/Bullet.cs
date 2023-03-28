using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] private Vector3 Srt;
    [SerializeField] private int Speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigid.AddForce(Vector2.right * Speed, ForceMode2D.Impulse);
    }
}
