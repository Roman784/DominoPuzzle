using UnityEngine;

public class PanelMenu : SceneMenu
{
    [SerializeField] private Panel _panel;

    public void OpenPanel()
    {
        PlayButtonCLickSound();
        _panel.Open();
    }

    public void ClosePanel()
    {
        PlayButtonCLickSound();
        _panel.Close();
    }
}
