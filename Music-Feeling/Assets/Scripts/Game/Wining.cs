using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wining : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something touched the finish line!");

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
