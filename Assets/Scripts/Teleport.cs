using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [Header("Teleport Exit")]
    [SerializeField] Transform exit;
    [Header("CharacterController")]
    [SerializeField] CharacterController controller;
    [Header("LoadingScreen")]
    [SerializeField] CanvasGroup fadeGroup;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(playTeleport(col));
        }
    }

    IEnumerator playTeleport(Collider col)
    {
        controller.enabled = false;
        StartCoroutine(fadeIn());
        yield return new WaitUntil(() => fadeGroup.alpha >= 1);
        col.transform.position = exit.position;
        col.transform.rotation = exit.rotation;
        StartCoroutine(fadeOut());
        controller.enabled = true;

    }

    IEnumerator fadeIn()
    {
        while (fadeGroup.alpha < 1)
        {
            fadeGroup.alpha += 0.01f;
            yield return null;
        }
    }

    IEnumerator fadeOut()
    {
        while (fadeGroup.alpha > 0)
        {
            fadeGroup.alpha -= 0.02f;
            yield return null;
        }
    }
}
