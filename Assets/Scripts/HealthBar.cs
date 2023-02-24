using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _bar;
    [SerializeField] private Gradient _gradientBar;
    [SerializeField] private Text _text;

    private readonly float _duration = 0.7f;

    private void OnEnable()
    {
        _player.ChangeHealth += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= OnChangeHealth;
    }

    private void OnChangeHealth(float currentValue, float maxValue)
    {
        float value = currentValue / maxValue;
        _bar.DOFillAmount(value, _duration);
        _bar.color = _gradientBar.Evaluate(value);
        _text.text = $"{(int)currentValue} / {(int)maxValue}";
    }
}