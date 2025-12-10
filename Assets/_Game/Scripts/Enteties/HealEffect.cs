using UnityEngine;

public class HealEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKeyDown(key: KeyCode.Space)) Play();
    }

    public void Play()
    {
        _particle.Play();
        _animator.SetTrigger("Heal");
    }
}