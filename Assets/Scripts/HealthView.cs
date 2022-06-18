using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private Parameters _parameters;

    private void Start()
    {
        _parameters.OnHealthChanged += ChangeView;
    }

    private void ChangeView(int value)
    {
        _view.text = "Здоровье\n" + value.ToString();
    }
}
