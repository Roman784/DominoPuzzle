using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Theme : MonoBehaviour
{
    private int _id;
    private bool _isUnlocked;

    [SerializeField] private ThemeConfig _config;

    [Space]

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _title;

    [Space]

    [SerializeField] private AudioSource _soundtrackPlayer;

    private ThemeAnimation _animation;
    private ThemeSound _sound;

    private void Awake()
    {
        Animator animator = GetComponent<Animator>();

        _animation = new ThemeAnimation(animator);
        _sound = new ThemeSound(_soundtrackPlayer, _config);
    }

    public void Init(int id, bool isUnlocked)
    {
        _id = id;
        _isUnlocked = isUnlocked;
    }

    public void Unlock() => _isUnlocked = true;

    public int Id => _id;
    public bool IsUnlocked => _isUnlocked;
    public ThemeConfig Config => _config;
    public ThemeAnimation Animation => _animation;
    public ThemeSound Sound => _sound;

    public void Activate()
    {
        _background.SetActive(true);
        _title.SetActive(true);
    }

    public void ActivateBackground()
    {
        _background.SetActive(true);
    }

    public void Deactivate()
    {
        _background.SetActive(false);
        _title.SetActive(false);
    }

    public void DeactivateTitle()
    {
        _title.SetActive(false);
    }

    public void Destroy()
    {
        // When switching scenes, if the current theme is not selected, the sound player is destroyed, but the routine still works.
        _sound.StopCurrentRoutine();

        Destroy(gameObject);
    }
}
