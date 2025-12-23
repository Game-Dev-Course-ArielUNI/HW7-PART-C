using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxLives = 3;
    private int currentLives;

    private void Awake()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int damage)
    {
        currentLives -= damage;
        Debug.Log($"Player hit! Lives left: {currentLives}");

        if (currentLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("PLAYER LOST");

        // Simple loss condition
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
