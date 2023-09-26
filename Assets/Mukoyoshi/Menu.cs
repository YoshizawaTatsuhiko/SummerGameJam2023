using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GoScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
