using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void Exit()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
