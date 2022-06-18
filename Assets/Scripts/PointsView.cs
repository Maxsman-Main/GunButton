using TMPro;
using UnityEngine;

public class PointsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private Parameters _parameters;

    private void Start()
    {
        _parameters.OnPointsChanged += ChangeView;
    }

    private void ChangeView(int value)
    {
        _view.text = "Очки\n" + value.ToString();
    }
}
