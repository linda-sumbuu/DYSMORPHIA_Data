using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    private void Update()
    {

    }
    public void SceneChange(int level)

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);

    }
}
