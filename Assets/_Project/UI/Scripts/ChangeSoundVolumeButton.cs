using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChangeSoundVolumeButton : MonoBehaviour
{
    [SerializeField] private Image _image;

    [Space]

    [SerializeField] private Sprite _onIcon;
    [SerializeField] private Sprite _offIcon;

    [Inject]
    private void Construct(AudioPlayer audioPlayer)
    {
        audioPlayer.OnVolumeChanged.AddListener(UpdateView);

        UpdateView(audioPlayer.Volume);
    }

    private void UpdateView(float volume)
    {
        _image.sprite = volume > 0f ? _onIcon : _offIcon;
    }
}
