using System;

public interface ITileBehavior
{
    public event Action OnCompleted;
    public void OnClick(Tile tile);
}
