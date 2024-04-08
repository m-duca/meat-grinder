using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampOilRecharge : MonoBehaviour
{
    public float radiusIncrease;
    LightIntensityRuntime _lightScript;

    private static AudioManager _audioManager;

    private void Start()
    {
        if (_audioManager == null)
            _audioManager = GameObject.FindObjectOfType<AudioManager>();

        _lightScript = GameObject.FindObjectOfType<LightIntensityRuntime>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidiu com o jogador
        if (other.CompareTag("Player"))
        {
            // Aumenta o raio externo da luz
            _lightScript.IncreaseRadius(radiusIncrease);

            _audioManager.PlaySFX("lantern");

            // Remove o objeto do jogo
            Destroy(gameObject);
        }
    }

}
