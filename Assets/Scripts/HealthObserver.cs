using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthObserver : MonoBehaviour
{
    [SerializeField] private Parameters _parameters;

    private void Start()
    {
        _parameters.OnHealthChanged += Lose;
    }

    private void Lose(int health)
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }
}
