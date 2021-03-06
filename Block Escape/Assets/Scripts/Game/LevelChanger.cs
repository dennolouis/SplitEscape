using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    int levelToLoad;

    public void FadeToLevel(int levelIndex)
    {
        Time.timeScale = 1;
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene(2);
    }
}
