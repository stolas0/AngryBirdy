using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelIndex = 1;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        foreach (var enemy in _enemies)
            if (enemy != null)
                return;

        _nextLevelIndex++;
        var Level = "Level" + _nextLevelIndex.ToString();
        SceneManager.LoadScene(Level);

    }
}
