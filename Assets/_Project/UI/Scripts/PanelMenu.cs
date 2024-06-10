using UnityEngine;

public class PanelMenu : Menu
{
    [SerializeField] private Panel _panel;

    public void OpenPanel()
    {
        _panel.Open();
    }

    public void ClosePanel()
    {
        _panel.Close();
    }
}
