using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Theme : MonoBehaviour
{
    private int _id;

    [SerializeField] private ThemeConfig _config;

    [Space]

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _title;

    private ThemeAnimation _animation;

    public void Init(int id)
    {
        _id = id;

        Animator animator = GetComponent<Animator>();
        _animation = new ThemeAnimation(animator);
    }

    public int Id => _id;
    public ThemeConfig Config => _config;
    public ThemeAnimation Animation => _animation;

    public void Activate()
    {
        _background.SetActive(true);
        _title.SetActive(true);
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
