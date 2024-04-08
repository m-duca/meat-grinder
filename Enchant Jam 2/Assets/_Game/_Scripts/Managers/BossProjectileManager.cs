using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileManager : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Configura��es:")]

    [Header("Pontos de Spawn:")]
    [SerializeField] private Transform[] spawnPoints;

    [Header("Tempo de Spawn:")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [Header("Prefab:")]
    [SerializeField] private BossProjectile bossProjectilePrefab;

    public static BossProjectileManager Instance;

    bool spawningInProgress = false;
    #endregion

    #region Fun��es Unity
    private void Awake() => Instance = this;

    private void Start() => StartCoroutine(SpawnNextProjectile());
    #endregion

    #region Fun��es Pr�prias
    public IEnumerator SpawnNextProjectile()
    {
        if (!spawningInProgress)
        {
            spawningInProgress = true;
            Debug.Log("SPAWNOU");
            //TODO: Mostrar Indicador
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Instantiate(bossProjectilePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            spawningInProgress = false;
        }
    }
    #endregion
}
