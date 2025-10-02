using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crimson.UI.But
{
    [CreateAssetMenu(fileName = "Change Scene", menuName = "Crimson/UI/Button/Change Scene")]
    public class ChangeScene : BaseButton
    {
        [Tooltip("The name of the scene we want to load")]
        [SerializeField]
        private string sceneName = string.Empty;

        public override void Execute()
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                return;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}