using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource _soundJump;
    public AudioSource _soundFall;
    public AudioSource _soundDeath;

    public AudioSource _soundCoin;

    private void OnEnable()
    {
        PlayerController.soundJump += Jump;
        PlayerController.soundFall += Fall;
        PlayerController.soundDeath += Death;

        PlayerCheckOnCoin.soundCoin += Coin;
    }

    private void OnDisable()
    {
        PlayerController.soundJump -= Jump;
        PlayerController.soundFall -= Fall;
        PlayerController.soundDeath -= Death;

        PlayerCheckOnCoin.soundCoin -= Coin;
    }

    private void Jump()
    {
        float randomPitch = Random.Range(0.8f, 1.0f);
        _soundJump.pitch = randomPitch;
        _soundJump.Play();
    }

    private void Fall()
    {
        float randomPitch = Random.Range(0.9f, 1.1f);
        _soundFall.pitch= randomPitch;
        _soundFall.Play();

    }

    private void Death()
    {
        _soundDeath.Play();
    }

    private void Coin()
    {
        _soundCoin.Play();
    }
}
