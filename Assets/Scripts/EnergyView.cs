using TMPro;
using UnityEngine;

public class EnergyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private GunButton _button;

    private void Start()
    {
        _button.OnEnergyChanged += ChangeView;
    }

    private void ChangeView(int value)
    {
        if (value < 0)
        {
            _view.text = "Энергия\n0/200";
        }
        else
        {
            _view.text = "Энергия\n" + value.ToString() + "/200";
        }
        if (value >= 50)
        {
            _view.color = Color.red;
        }
        else
        {
            _view.color = Color.white;
        }
    }
}
