using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float _fadeDuration = 1f;
    public float _dispalyImageDuration = 1f;
    public CanvasGroup _exitBackgroundImageCanvasGroup;
    public CanvasGroup _caughtBackgroundImageCanvasGroup;
    public GameObject _player;

    public AudioSource _exitAudio;
    public AudioSource _caughtAudio;

    float m_timer;
    bool m_isPlayerAtExit;
    bool m_isPlayerCaught;
    bool m_HasAudioPlayed;


    private void Update()
    {
        if (m_isPlayerAtExit)
        {
            EndLevel(_exitBackgroundImageCanvasGroup, false, _exitAudio);
        }
        else if (m_isPlayerCaught)
        {
            EndLevel(_caughtBackgroundImageCanvasGroup, true, _caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_timer / _fadeDuration;

        if (m_timer > _fadeDuration + _dispalyImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            m_isPlayerAtExit = true;
        }
    }
    public void CaughtPlayer()
    {
        m_isPlayerCaught = true;
    }

}
