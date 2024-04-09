using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveVFX : MonoBehaviour
{
    [Header("Move Effect")]
    [SerializeField] private Color effectColor;
    [SerializeField] private GameObject playerEffectPrefab;

    private void Start() => StartCoroutine(ApplyEffect(0.02f));

    private IEnumerator ApplyEffect(float t)
    {
        yield return new WaitForSeconds(t);
        var effect = Instantiate(playerEffectPrefab, transform.position, Quaternion.identity);
        var effectSpr = effect.GetComponent<SpriteRenderer>();
        playerEffectPrefab.transform.localScale = gameObject.transform.localScale;
        effectSpr.sprite = GetComponent<SpriteRenderer>().sprite;
        effectSpr.color = effectColor;
        effectSpr.flipX = GetComponent<SpriteRenderer>().flipX;
        StartCoroutine(ApplyEffect(0.02f));
    }
}
