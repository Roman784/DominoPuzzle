using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Theme : MonoBehaviour
{
    private int _id;

    [SerializeField] private ThemeConfig _config;

    [Space]

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _title;

    [Space]

    [SerializeField] private AudioSource _soundtrackPlayer;

    private ThemeAnimation _animation;
    private ThemeSound _sound;

    public void Init(int id)
    {
        _id = id;

        Animator animator = GetComponent<Animator>();

        _animation = new ThemeAnimation(animator);
        _sound = new ThemeSound(_soundtrackPlayer, _config);
    }

    public int Id => _id;
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
        Destroy(gameObject);
    }
}
