using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private Bird _bird;
    private Canvas finishScreen;
    static bool _isBirdLaunched;
    bool _IsPassedtimeSittingAround;
    private static int _nextLevelIndex = 1;
    string Level;
    private int MaxLevel;

    private void Awake()
    {
        finishScreen = GetComponent<Canvas>();
        MaxLevel = SceneManager.sceneCountInBuildSettings;
        //DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _bird = FindObjectOfType<Bird>();
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        //if (!SceneManager.GetSceneByName(Level).isLoaded)
        //    return;

        if (_isBirdLaunched && _bird.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
            StartCoroutine("Cooldown");

        if (Mathf.Abs(transform.position.y) > 6 || Mathf.Abs(transform.position.x) > 18 || _IsPassedtimeSittingAround)
            LoadLevel();
    }

    private void LoadLevel()
    {
        _isBirdLaunched = false;
        _IsPassedtimeSittingAround = false;

        CheckAllEnemiesDie();
        Level = "Level" + _nextLevelIndex.ToString();

        if (_nextLevelIndex > MaxLevel)
            FinishGame();
        else
            SceneManager.LoadScene(Level);
    }

    private void FinishGame()
    {
        //Instantiate(_FinishGame);
        //finishScreen.enabled = true;
        Debug.Log("Thats all folks");
        SceneManager.LoadScene("Level1");
    }

    static public void BirdWasLaunched()
    {
        _isBirdLaunched = true;
    }

    private void CheckAllEnemiesDie()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy != null)
                return;
        }
        _nextLevelIndex++;
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(5f);
        _IsPassedtimeSittingAround = true;
    }
}
