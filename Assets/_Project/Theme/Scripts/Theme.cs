using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Theme : MonoBehaviour
{
    [SerializeField] private GameObject _sprites;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _sprites.SetActive(false);
    }

    public void Activate()
    {
        _sprites.SetActive(true);
    }

    public void Appearance()
    {
        Activate();
        _animator.SetTrigger("Appearance");
    }

    public void Disappearance()
    {
        _animator.SetTrigger("Disappearance");
    }
}
