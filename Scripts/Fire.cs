using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Transform startShoot;
    [SerializeField] private GameObject round;
    [SerializeField] private ParticleSystem fireShoot;
    [SerializeField] private Animator _animator;
    [SerializeField] private float temp;
    [SerializeField] private AudioSource _audioSource;

    public async void GenerationFire()
    {
        Time.timeScale = 1;
        _audioSource.Play();
        Instantiate(round, startShoot);
        fireShoot.Play();
        _animator.SetBool("isShoot", true); 
        await Task.Delay(50);
        _animator.SetBool("isShoot", false);
    }
}
