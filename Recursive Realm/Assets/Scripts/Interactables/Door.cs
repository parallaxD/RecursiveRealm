using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private GameObject _doorPasswordCanvas;

    public bool IsOpen;

    [SerializeField] private VideoPlayerController _videoPlayer;
    [SerializeField] private GameObject _videos;
    protected override void Interact()
    {
        if (IsOpen)
        {
            _videos.SetActive(true);
            _videoPlayer.PlayVideo(3);
        }
        else _doorPasswordCanvas.SetActive(true);
    }
}
