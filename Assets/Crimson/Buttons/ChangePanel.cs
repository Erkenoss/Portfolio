using Portfolio.MainMenu;
using UnityEngine;

namespace Crimson.UI.But
{
    [CreateAssetMenu(fileName = "ChangePanel", menuName = "UI/Button/ChangePanel")]
    public class ChangePanel : BaseButton
    {
        public override void Execute(GameObject panel)
        {
            if (panel == null || MenuManager.Instance == null)
            {
                return;
            }

            MenuManager.Instance.OpenPanel(panel);
        }
    }
}