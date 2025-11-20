using System;
using Hero;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed = 10f;

    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<HeroController>().transform;
    }

    private void LateUpdate()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);

        transform.position = smoothPosition;
        transform.LookAt(_target);
    }
}