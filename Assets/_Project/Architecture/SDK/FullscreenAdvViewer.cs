using UnityEngine;
using Zenject;

public class FullscreenAdvViewer : MonoBehaviour
{
    [Inject]
    private void Construct(SDK SDK)
    {
        SDK.ShowFullscreenAdv();
    }
}
