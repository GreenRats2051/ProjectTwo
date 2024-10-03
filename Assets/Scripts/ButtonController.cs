using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Retry(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
