using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;
using System;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] RawImage _rawImage;
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] List<VideoClip> _videos;
    [SerializeField] GameObject _videoCanvas;
    [SerializeField] SceneChanger _sceneChanger;


    void Awake()
    {
        _videoPlayer.targetTexture = new RenderTexture(1920, 1080, 0);
        _rawImage.texture = _videoPlayer.targetTexture;
        _videoPlayer.enabled = false;
        _rawImage.enabled = false;
        _videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_videoPlayer.clip == _videos[_videos.Count - 1])
            {
                _sceneChanger.LoadScene("MainMenu");
                Cursor.lockState = CursorLockMode.None;
            }
            _videoCanvas.SetActive(false);
            SoundManager.AudioMixerMaster.audioMixer.SetFloat("Volume", GameManager.SoundValue);
        }
    }

    private void OnVideoEnd(VideoPlayer videoPlayer)
    {
        if (_videoPlayer.clip == _videos[_videos.Count - 1])
        {
            Cursor.lockState = CursorLockMode.None;
            _sceneChanger.LoadScene("MainMenu");
        }
        SoundManager.AudioMixerMaster.audioMixer.SetFloat("Volume", GameManager.SoundValue);
        _videoCanvas.SetActive(false);
    }

    public void PlayVideo(int videoIndex)
    {
        SoundManager.AudioMixerMaster.audioMixer.GetFloat("Volume", out GameManager.SoundValue);
        SoundManager.AudioMixerMaster.audioMixer.SetFloat("Volume", -80);
        _videoPlayer.enabled = true;
        _rawImage.enabled = true;
        _videoPlayer.clip = _videos[videoIndex];
        _videoPlayer.Play();
    }
}
