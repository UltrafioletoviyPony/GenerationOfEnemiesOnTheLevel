using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;
    private float _repeatTime = 2f;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_repeatTime);
    }

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(nameof(SpawnRepeating));
    }

    private void CreateEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.transform.position = GetRandomPositionFromSpawnPoints();
        enemy.transform.eulerAngles = CreateRandomUpVector();
    }

    private Vector3 GetRandomPositionFromSpawnPoints()
    {
        int minPointNumber = 0;
        int maxPointNumber = _spawnPoints.Count;
        int pointNumber = UnityEngine.Random.Range(minPointNumber, maxPointNumber);

        return _spawnPoints[pointNumber].position;
    }

    private Vector3 CreateRandomUpVector()
    {
        float minValue = 0;
        float maxValue = 360;
        float upVectorValue = Random.Range(minValue, maxValue);

        return new Vector3(0, upVectorValue, 0);
    }

    private IEnumerator SpawnRepeating()
    {
        bool isRuned = true;

        while (isRuned)
        {
            CreateEnemy();
            yield return _waitForSeconds;
        }
    }
}