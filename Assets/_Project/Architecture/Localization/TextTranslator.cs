using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class TextTranslator : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;

    private TMP_Text _text;
    private Localization _localization;

    [Inject]
    private void Construct(Localization localization)
    {
        _text = GetComponent<TMP_Text>();
        _localization = localization;

        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _localization.GetLanguage() == Language.Ru ? _ru : _en;
    }
}
