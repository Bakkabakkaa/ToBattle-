using System;
using UnityEngine;
using UnityEngine.AI;

public class HeroAnimator : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private Animator _animator;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var isWalking = _agent.velocity.magnitude > 0.1f;
        _animator.SetBool(IsWalking, isWalking);
    }
}