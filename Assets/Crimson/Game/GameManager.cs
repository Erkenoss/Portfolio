using Crimson.Language;
using Crimson.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region Public Fields

    public float Gravity { get { return gravity; } }

    #endregion

    #region Private Fields

    [Tooltip("Gravity of the game")]
    [SerializeField]
    private float gravity = 1f;

    #endregion

    #region MonoBehaviour Callbacks

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
    #endregion

    #region Public Methods

    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (LanguageManager.Instance != null)
        {
            LanguageManager.Instance.OnSceneLoad();
        }
    }

    #endregion

    #region Private Methods
    #endregion
}
