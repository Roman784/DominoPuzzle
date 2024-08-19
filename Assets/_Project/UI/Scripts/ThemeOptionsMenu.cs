using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ThemeOptionsMenu : SceneMenu
{
    [SerializeField] private Image _selectButtonView;
    [SerializeField] private Sprite _selectSprite;
    [SerializeField] private Sprite _adSprite;
    [SerializeField] private GameObject _adOfferView;

    private ThemeOptions _options;

    [Inject]
    private void Construct (Storage storage, CurrentTheme currentTheme, ThemeCreator creator, ThemeCreationConfig creationConfig)
    {
        _options = new ThemeOptions(storage, currentTheme, creator, creationConfig);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            SwitchToNext();
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            SwitchToPrevious();
    }

    public void Select()
    {
        bool isUnlocked = _options.ViewedTheme.IsUnlocked;

        if (isUnlocked)
        {
            SDK.ShowFullscreenAdv();

            _options.Select();
            OpenGameplayScene();
        }
        else
        {
            SDK.ShowRewardedVideo((bool res) =>
            {
                if (res)
                    UnlockViewedTheme();
            });
        }
    }

    public void SwitchToNext()
    {
        PlayButtonCLickSound();

        _options.Switch(1);
        UpdateSelectButtonView();
    }

    public void SwitchToPrevious()
    {
        PlayButtonCLickSound();

        _options.Switch(-1);
        UpdateSelectButtonView();
    }

    private void UnlockViewedTheme()
    {
        _options.UnlockViewedTheme();
        UpdateSelectButtonView();
    }

    private void UpdateSelectButtonView()
    {
        bool isUnlocked = _options.ViewedTheme.IsUnlocked;

        _selectButtonView.sprite = isUnlocked ? _selectSprite : _adSprite;
        _adOfferView.SetActive(!isUnlocked);
    }
}
