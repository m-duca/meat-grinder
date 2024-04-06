using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerManager : MonoBehaviour
{
    #region Variáveis Globais
    [Header("Configurações:")]

    [Header("Tempo:")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [Header("Referências:")]
    [SerializeField] private GameObject[] obstaclesPrefabs;
    [SerializeField] private Transform spawnPoint;
    #endregion

    #region Funções Unity
    private void Start() => StartCoroutine(SpawnNextObstacle(minTime, maxTime));
    #endregion

    #region Funções Próprias
    private IEnumerator SpawnNextObstacle(float minTime, float maxTime)
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));

        Instantiate(obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)], spawnPoint.position,
            Quaternion.identity);

        StartCoroutine(SpawnNextObstacle(minTime, maxTime));
    }
    #endregion
}
