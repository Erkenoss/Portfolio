using UnityEngine;

namespace Crimson.UI.But
{
    [CreateAssetMenu(fileName = "Open Panel", menuName = "Crimson/UI/Button/Open Panel")]
    public class OpenPanel : BaseButton
    {
        public override void Execute(GameObject panel)
        {
            if (panel == null)
            {
                return;
            }

            panel.SetActive(true);
        }
    }
}
