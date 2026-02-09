using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] private float _spawnRadius = 1f;
    [SerializeField] private float _spawnInterval = 5f;
    [SerializeField] private Transform _target;

    private float _lastSpawnTime = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>= _lastSpawnTime + _spawnInterval)
        {

            Enemy enemy = Instantiate(_enemyPrefab,new Vec)
        }
    }
}
