using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
