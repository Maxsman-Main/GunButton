using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Transform _transofrm;

    private void Start()
    {
        _transofrm = gameObject.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Rotate(_rotationSpeed);
    }

    private void Rotate(float zAngle)
    {
        _transofrm.Rotate(0, 0, zAngle);
    }
}
