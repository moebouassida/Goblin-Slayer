using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Door : MonoBehaviour
{
    public Inventory inventory;
    public LevelChanger changer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( (collision.CompareTag("Player")) && (inventory.coinsCount == 4) )
        {
            changer.FadeToNextLevel();
        }
    }
}
