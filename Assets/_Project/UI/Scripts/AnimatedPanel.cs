using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatedPanel : Panel
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Open()
    {
        _animator.SetTrigger("Open");
    }

    public override void Close ()
    {
        _animator.SetTrigger("Close");
    }
}
