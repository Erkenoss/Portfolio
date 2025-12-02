using UnityEngine;

namespace Crimson.UI.But
{
    [CreateAssetMenu(fileName = "Open Close Panel", menuName = "Crimson/UI/Button/Open Close Panel")]
    public class OpenClosePanel : BaseButton
    {
        public override void Execute(GameObject panel)
        {
            if (panel == null)
            {
                return;
            }

            panel.SetActive(!panel.activeSelf);
        }
    }
}
