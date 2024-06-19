using UnityEngine;

public class PanelMenu : SceneMenu
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
