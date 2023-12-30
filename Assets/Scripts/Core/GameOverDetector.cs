using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    public void IsGameOver(int currentHealth, int maxHealth)
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
