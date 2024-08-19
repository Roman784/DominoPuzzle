using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Animator))]
public class NextLevelButton : MonoBehaviour
{
    private Field _field;
    private SceneTransition _sceneTransition;
    private FieldCreationConfig _fieldCreationConfig;
    private SDK _SDK;

    private Animator _animator;

    [SerializeField] private Image _view;

    [Inject]
    private void Construct(LevelCompletionHandler levelCompletionHandler, Field field, 
                           SceneTransition sceneTransition, FieldCreationConfig fieldCreationConfig,
                           CurrentTheme currentTheme, SDK SDK)
    {
        _field = field;
        _sceneTransition = sceneTransition;
        _fieldCreationConfig = fieldCreationConfig;
        _SDK = SDK;

        levelCompletionHandler.OnCompleted.AddListener(Show);

        SetColor(currentTheme.Config.MainColor);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenNextLevel()
    {
        _SDK.ShowFullscreenAdv();

        Hide();
        StartCoroutine(OpenNextLevelRoutine());
    }

    private IEnumerator OpenNextLevelRoutine()
    {
        yield return new WaitForSeconds(0.15f);

        _field.Animation.TileDisappearance();
        _field.Sound.PlayTileDisappearanceSound();

        yield return new WaitForSeconds(1.5f);

        OpeningLevel.Next();
        if (OpeningLevel.Number > _fieldCreationConfig.MaxNumber)
            _sceneTransition.OpenLevelListScenen();
        else
            _sceneTransition.OpenGameplayScene();
    }

    public void Show()
    {
        _animator.SetTrigger("Show");
    }

    private void Hide()
    {
        _animator.SetTrigger("Hide");
    }

    private void SetColor(Color color)
    {
        _view.color = color;
    }
}
