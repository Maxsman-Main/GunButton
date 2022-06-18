using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Laser _laser;

    public void Fire(float laserLifeTime)
    {
        StartCoroutine(FireWithWait(_laser, laserLifeTime));
    }

    private IEnumerator FireWithWait(Laser laser, float waitTime)
    {
        laser.Activate();
        yield return new WaitForSeconds(waitTime);
        laser.Deactivate();
    } 
}