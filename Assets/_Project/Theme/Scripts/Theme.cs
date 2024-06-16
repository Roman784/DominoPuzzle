using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Theme : MonoBehaviour
{
    private int _id;

    [SerializeField] private ThemeConfig _config;

    [Space]

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _title;

    private Animator _animator;

    public void Init(int id)
    {
        _id = id;

        _animator = GetComponent<Animator>();
    }

    public int Id => _id;
    public ThemeConfig Config => _config;

    public void ActivateFully()
    {
        _background.SetActive(true);
        _title.SetActive(true);
    }

    public void DeactivateTitle()
    {
        _title.SetActive(false);
    }

    public void DeactivateFully()
    {
        _background.SetActive(false);
        _title.SetActive(false);
    }

    public void Appearance()
    {
        _animator.SetTrigger("Appearance");
    }

    public void Disappearance()
    {
        _animator.SetTrigger("Disappearance");
    }
}
