using UnityEngine;

public class TileAnimation
{
    private Animator _animator;

    public TileAnimation(Animator animator)
    {
        _animator = animator;
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
