using System;
using TMPro;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] protected int _points;
    [SerializeField] protected int _damage;
    [SerializeField] protected Parameters _parameters;
    
    public event Action OnReactedToLaser;
    public event Action OnReactedToPlayer;

    public int Points => _points;

    protected abstract void ReactToLaser();
    protected abstract void ReactToPlayer();

    public void SetComponents(Transform target, Parameters parameters)
    {
        _target = target;
        _parameters = parameters;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Laser laser))
        {
            OnReactedToLaser?.Invoke();
            ReactToLaser();
        }

        if (col.gameObject.TryGetComponent(out GunButton gunButton))
        {
            OnReactedToPlayer?.Invoke();
            ReactToPlayer();
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
            _target.transform.position,
            _speed * Time.deltaTime);
    }
}
