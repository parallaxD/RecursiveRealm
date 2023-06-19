using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : Interactable
{
    protected override void Interact()
    {
        if (!HasInteracted)
        {
            StartCoroutine(PlayerThoughts.Thought("�������� �����. � ���� ����� �� �� ������� �����"));
            HasInteracted = true;
        }
        else
        {
            StartCoroutine(PlayerThoughts.Thought("����� �� ���� ��� �������"));
        }
    }
}
