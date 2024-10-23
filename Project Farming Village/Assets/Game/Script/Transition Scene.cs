using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public Animator transition;  // Corrected the typo
    public float transitionTime = 1f;
    public string levelToLoad;  // Added levelToLoad as a public field

    void OnTriggerEnter2D(Collider2D other)  // Updated for 2D
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Work");
            DataPersistenceManager.Instance.SaveGame();
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScreenAsync(levelToLoad));
    }

    IEnumerator LoadScreenAsync(string levelToLoad)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelToLoad);
    }
}
