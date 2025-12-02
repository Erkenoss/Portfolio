using UnityEngine;

namespace Crimson.UI.But
{
    [CreateAssetMenu(fileName = "GoURL", menuName = "Crimson/UI/Button/GoURL")]
    public class GoURL : BaseButton
    {
        [Tooltip("Url where we want to go")]
        [SerializeField]
        private string url = string.Empty;

        public override void Execute()
        {
            Application.OpenURL(url);
        }
    }
}