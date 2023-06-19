using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureKey : Interactable
{
    protected override void Interact()
    {
        StartCoroutine(PlayerThoughts.Thought("Что открывает этот ключ?"));
        StartCoroutine(Delete());
        GameObject.Find("картина").GetComponent<BoxCollider>().enabled = true;
    }

    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        GameManager.IsPlayerHasKey = true;
        SoundManager.PlaySound(InteractSound);
    }
}
