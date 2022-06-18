using System;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _points;
    
    public event Action<int> OnHealthChanged;
    public event Action<int> OnPointsChanged;

    public void UpdateHealth(int value)
    {
        _health += value;
        OnHealthChanged?.Invoke(_health);
    }

    public void UpdatePoints(int value)
    {
        _points += value;
        OnPointsChanged?.Invoke(_points);
    }
}
