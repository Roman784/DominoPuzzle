using UnityEngine;

public class TileLocker : MonoBehaviour
{
    private bool _isLocked;

    [SerializeField] private GameObject _frame;

    public bool IsLocked => _isLocked;

    public void Lock()
    {
        _isLocked = true;
        _frame.SetActive(true);
    }

    public void Unlock()
    {
        _isLocked = false;
        _frame.SetActive(false);
    }
}
