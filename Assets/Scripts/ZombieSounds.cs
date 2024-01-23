using UnityEngine;

public class ZombieSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _crySFX;
    [SerializeField] private AudioClip _agonySFX;
    [SerializeField] private AudioClip[] _attackSFX;
    [SerializeField] private AudioClip _idleSFX;
    [SerializeField] private AudioClip _stepSFX;
    [SerializeField] private AudioClip _deathSFX;

    [Header("Cutoff Frequency")]
    public float closeDistance = 5f;
    public float farDistance = 300f;
    public float maxCutoffFrequency = 11000f;
    public float minCutoffFrequency = 1000f;

    private AudioSource _soundSource;
    private AudioListener _listener;
    private AudioLowPassFilter _filter;

    private void Start()
    {
        _listener = FindObjectOfType<AudioListener>();
        _soundSource = GetComponent<AudioSource>();
        _filter = GetComponent<AudioLowPassFilter>();
    }

    private void Update()
    {
        ChangeFilterFromDistance();
    }

    private void ChangeFilterFromDistance()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _listener.transform.position);
        float t = Mathf.InverseLerp(closeDistance, farDistance, distanceToPlayer);
        float targetCutoffFrequency = Mathf.Lerp(maxCutoffFrequency, minCutoffFrequency, t);
        _filter.cutoffFrequency = targetCutoffFrequency;
    }

    public void CryEvent()
    {
        _soundSource.PlayOneShot(_crySFX);
    }

    public void AgonyEvent()
    {
        _soundSource.PlayOneShot(_agonySFX);
    }

    public void IdleEvent()
    {
        _soundSource.clip = _idleSFX;
        _soundSource.Play();
    }

    public void AttackHitEvent()
    {
        int randomIndex = Random.Range(0, _attackSFX.Length);
        _soundSource.PlayOneShot(_attackSFX[randomIndex], 0.3f);
    }

    public void StepEvent()
    {
        float pitch = Random.Range(1f, 1.3f);
        _soundSource.pitch = pitch;
        _soundSource.PlayOneShot(_stepSFX, 0.1f);
    }

    public void DeathEvent()
    {
        _soundSource.PlayOneShot(_deathSFX, 0.5f);
    }
}