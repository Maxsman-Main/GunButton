using System;
using UnityEngine;

public class GunButton : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private Car _car;
    [SerializeField] private int _energy;
    [SerializeField] private CameraShake _cameraShake;
    [SerializeField] private SpriteRenderer _gunSprite;
    [SerializeField] private SpriteRenderer _towerSprite;

    public event Action<int> OnEnergyChanged;
    
    private int _currentEnergy;
    private int _energyDelta = 1;
    private int _powerDelta = 1;
    private int _dragPower = 0;
    private bool _isCharging = false;
    private bool _isCoolsDown = false;
    private AudioSource _source;
    
    private void Start()
    {
        _currentEnergy = _energy;
        _source = gameObject.GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (!_isCharging)
        {
            if (_currentEnergy <= _energy)
            {
                _currentEnergy += _energyDelta;
                _cameraShake.StartShake((_energy - _currentEnergy) * 0.01f);
                OnEnergyChanged?.Invoke(_energy - _currentEnergy);
                if (_currentEnergy >= _energy)
                {
                    _cameraShake.EndShake();
                    _isCoolsDown = false;
                }
            }
        }
    }
    
    private void OnMouseDrag()
    {
        _gunSprite.color = Color.magenta;
        _towerSprite.color = Color.magenta;
        _isCharging = true;
        if (_currentEnergy > 0 && !_isCoolsDown)
        {
            //_cameraShake.StartShake(_dragPower * 0.01f);
            _currentEnergy -= _energyDelta;
            _dragPower += _powerDelta;
            OnEnergyChanged?.Invoke(_energy - _currentEnergy);
        }
    }

    private void OnMouseUp()
    {
        _isCharging = false;
        if (_currentEnergy <= _energy - 50) 
        {
            Attack(_dragPower);
        }
        _dragPower = 0;
    }

    private void OnMouseEnter()
    {
        _gunSprite.color = Color.yellow;
        _towerSprite.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        _gunSprite.color = Color.red;
        _towerSprite.color = Color.red;
    }

    private void Attack(float dragPower)
    {
        _source.Play();
        _cameraShake.StartShake(dragPower * 0.01f);
        _gun.Fire(dragPower * 0.005f); 
        //_car.PushSelf(dragPower * 0.01f);
        _isCoolsDown = true;
    }
}
