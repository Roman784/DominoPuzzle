using UnityEngine;
using UnityEngine.UI;

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

    public bool TrySetColor(Color color)
    {
        if (_panel.TryGetComponent<Image>(out Image image))
        {
            image.color = color;
            return true;
        }
        return false;
    }
}
