using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed;
    private Coroutine _coroutine;

    private void Awake() =>
        _speed = 0.015f;

    public void Init(Vector3 position, Vector3 rotation)
    {
        transform.position = position;
        transform.eulerAngles = rotation;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(MovingForward());
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