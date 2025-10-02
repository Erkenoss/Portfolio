using UnityEngine;

namespace Crimson.UI.But
{
    [CreateAssetMenu(fileName = "QuitButton", menuName = "Crimson/UI/Button/Quit")]
    public class QuitButton : BaseButton
    {
        public override void Execute()
        {
            Application.Quit();
        }
    }
}