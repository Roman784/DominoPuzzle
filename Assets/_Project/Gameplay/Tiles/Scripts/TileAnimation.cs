using UnityEngine;

public class TileAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Appearance()
    {
        _animator.SetTrigger("Appearance");
    }

    public void Disappearance()
    {
        _animator.SetTrigger("Disappearance");
    }

    public void Selection()
    {
        _animator.SetTrigger("Selection");
    }

    public void Deselection()
    {
        _animator.SetTrigger("Deselection");
    }
}
