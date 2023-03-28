using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float atkTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(AtkTime());
    }

    IEnumerator AtkTime()
    {
        animator.Play("PlayerShoot");
        yield return new WaitForSeconds(atkTime);
        StartCoroutine(AtkTime());
    }
}
