using UnityEngine;

namespace Crimson.UI.But
{
    [CreateAssetMenu(fileName = "Close Panel", menuName = "Crimson/UI/Button/Close Panel")]
    public class ClosePanel : BaseButton
    {
        public override void Execute(GameObject panel)
        {
            if (panel == null)
            {
                return;
            }

            panel.SetActive(false);
        }
    }
}
