using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Animator fadeAnim;
    public void LoadNextLevel()

    {
      
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        fadeAnim.SetTrigger("Fade");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(LevelIndex);
    }
}
