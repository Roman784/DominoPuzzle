using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Theme : MonoBehaviour
{
    [SerializeField] private ThemeConfig _config;

    [Space]

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _title;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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
        ActivateFully();
        _animator.SetTrigger("Appearance");
    }

    public void Disappearance()
    {
        _animator.SetTrigger("Disappearance");
    }
}
