using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _health;
    private readonly float _minHealth = 0f;
    private readonly float _maxHealth = 100f;
    private float _healValue = 10f;
    private float _damageValue = 10f;

    public UnityAction<float, float> ChangeHealth;

    private void Start()
    {
        _health = _maxHealth;
        ChangeHealth?.Invoke(_health, _maxHealth);
    }

    public void Heal()
    {
        _health = Mathf.Clamp(_health + _healValue, _minHealth, _maxHealth);
        ChangeHealth?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage()
    {
        _health = Mathf.Clamp(_health - _damageValue, _minHealth, _maxHealth);
        ChangeHealth?.Invoke(_health, _maxHealth);
    }

    public void SetRandomValue()
    {
        _health = Mathf.Clamp(Random.Range(_minHealth, _maxHealth), _minHealth, _maxHealth);
        ChangeHealth?.Invoke(_health, _maxHealth);
    }
}
