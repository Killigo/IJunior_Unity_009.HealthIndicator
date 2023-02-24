using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _health;
    private float _duration = 0.7f;
    private float _minHealth = 0f;
    private float _maxHealth = 100f;
    private float _healValue = 10f;
    private float _damageValue = 10f;

    private void Start()
    {
        _slider.minValue = _minHealth;
        _slider.maxValue = _maxHealth;
        _health = 50f;
    }

    private void Update()
    {
        _slider.DOValue(_health, _duration);
    }

    public void Heal()
    {
        if (_health < _maxHealth - _healValue)
            _health += _healValue;
        else
            _health = _maxHealth;
    }

    public void Damage()
    {
        if (_health > _minHealth + _damageValue)
            _health -= _damageValue;
        else
            _health = _minHealth;
    }

    public void SetRandomHealth()
    {
        _health = Random.Range(_minHealth, _maxHealth);
    }
}
