using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : Interactable
{
    protected override void Interact()
    {
        StartCoroutine(PlayerThoughts.Thought("����� ����� ���� ������� �� ������ ������"));
        StartCoroutine(Delete());
    }

    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        GameManager.IsPlayerHasNotebook = true;
        SoundManager.PlaySound(InteractSound);
    }
}
