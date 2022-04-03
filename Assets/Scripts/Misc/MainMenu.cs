using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void Play()
    {
        StartCoroutine(LoadLevel(1));
    }

    public IEnumerator LoadLevel(int level)
    {
        Cursor.visible = false;
        _anim.SetTrigger("Start");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}