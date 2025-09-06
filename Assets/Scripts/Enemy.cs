using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed;
    private Coroutine _coroutine;

    private void Awake()
    {
        _speed = 0.015f;
    }

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(nameof(MovingForward));
    }

    private IEnumerator MovingForward()
    {
        bool isMoving = true;

        while (isMoving)
        {
            transform.Translate(Vector3.forward * _speed, Space.Self);
            yield return null;
        }
    }
}