using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Transform _enemyTarget;
    [SerializeField] private float lowXBound;
    [SerializeField] private float topXBound;
    [SerializeField] private float lowYBound;
    [SerializeField] private float topYBound;
    [SerializeField] private float lowTimeBound;
    [SerializeField] private float topTimeBound;
    [SerializeField] private Parameters _parameters;
    
    
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var xPosition = Random.Range(lowXBound, topXBound);
            var yPosition = Random.Range(lowYBound, topYBound);
            var index = Random.Range(0, _enemies.Count);
            var nextEnemy = _enemies[index];
            var time = Random.Range(lowTimeBound, topTimeBound);
            if (index == 0)
            {
                var enemyObject = Instantiate(nextEnemy, new Vector3(xPosition, yPosition, 5), Quaternion.identity);
                enemyObject.SetComponents(_enemyTarget, _parameters);
            }
            else if (index == 1)
            {
                var enemyObject = Instantiate(nextEnemy, new Vector3(xPosition, yPosition, 8), Quaternion.identity);
                enemyObject.SetComponents(_enemyTarget, _parameters);
            }
            else
            {
                var enemyObject = Instantiate(nextEnemy, new Vector3(xPosition, yPosition, 3), Quaternion.identity);
                enemyObject.SetComponents(_enemyTarget, _parameters);
            }
            yield return new WaitForSeconds(time);
        }
    }
}
