using System.Collections;
using UnityEngine;
using TMPro;

public class Massager : MonoBehaviour
{
    [SerializeField] private TMP_Text _damageMessage;
    [SerializeField] private TMP_Text _pointsMessage;
    
    public IEnumerator ShowDamageMessage(int value, Transform position)
    {
        _damageMessage.text = "-" + value.ToString();
        _damageMessage.color = Color.red;
        var messageView = Instantiate(_damageMessage, position);
        yield return new WaitForSeconds(2);
        Destroy(messageView);
    }
    
    public IEnumerator ShowPointsMessage(int value, Transform position)
    {
        _pointsMessage.text = "+" + value.ToString();
        _pointsMessage.color = Color.green;
        var messageView = Instantiate(_pointsMessage, position);
        yield return new WaitForSeconds(2);
        Destroy(messageView);
    }
}
