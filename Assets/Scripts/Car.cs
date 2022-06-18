using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    
    public void PushSelf(float pushPower)
    {
        var direction = -1 * _tower.transform.right;
        gameObject.transform.Translate(direction * pushPower);
    }
}
