using TMPro;
using UnityEngine;

public class ShowingMaxScore : MonoBehaviour
{
    private TextMeshProUGUI _maxScoreText;
    private void Awake()
    {
        _maxScoreText= GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        _maxScoreText.text = Database.instance.GetMaxScore().ToString();
    }
}
