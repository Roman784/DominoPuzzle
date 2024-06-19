using UnityEngine;

public class ThemeAnimation
{
    private Animator _animator;

    public ThemeAnimation(Animator animator)
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
}
