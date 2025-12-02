using Crimson.UI.But;
using UnityEngine;

namespace Portfolio.MainMenu
{
    [CreateAssetMenu(fileName = "Portfolio OpenClose Setting", menuName = "Portfolio/Button/Open Close Setting Panel")]
    public class OpenCloseSettingPanel : OpenClosePanel
    {
        public override void Execute(GameObject panel)
        {
            if (panel == null || MenuManager.Instance == null)
            {
                return;
            }

            MenuManager.Instance.OpenCloseSettingPanel(panel);
        }
    }
}
