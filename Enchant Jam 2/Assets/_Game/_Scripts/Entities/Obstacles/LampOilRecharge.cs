using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampOilRecharge : MonoBehaviour
{
    public float radiusIncrease;
    LightIntensityRuntime _lightScript;

    private void Start()
    {
        _lightScript = GameObject.FindObjectOfType<LightIntensityRuntime>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidiu com o jogador
        if (other.CompareTag("Player"))
        {
            // Aumenta o raio externo da luz
            _lightScript.IncreaseRadius(radiusIncrease);

            // Remove o objeto do jogo
            Destroy(gameObject);
        }
    }

}
