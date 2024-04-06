using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerManager : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Configura��es:")]

    [Header("Tempo:")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [Header("Refer�ncias:")]
    [SerializeField] private GameObject[] obstaclesPrefabs;
    [SerializeField] private Transform spawnPoint;
    #endregion

    #region Fun��es Unity
    private void Start() => StartCoroutine(SpawnNextObstacle(minTime, maxTime));
    #endregion

    #region Fun��es Pr�prias
    private IEnumerator SpawnNextObstacle(float minTime, float maxTime)
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));

        Instantiate(obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)], spawnPoint.position,
            Quaternion.identity);

        StartCoroutine(SpawnNextObstacle(minTime, maxTime));
    }
    #endregion
}
