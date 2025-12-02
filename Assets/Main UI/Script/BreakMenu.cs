using UnityEngine;
using Crimson.UI.But;
using Crimson.Portfolio;

namespace Portfolio.MainMenu
{
    [CreateAssetMenu(fileName = "BreakMenu", menuName = "Portfolio/Button/Break Menu")]
    public class BreakMenu : BaseButton
    {
        public override void Execute(GameObject breakPanel)
        {
            if (breakPanel == null || PortfolioUIManager.Instance == null)
            {
                return;
            }

            PortfolioUIManager.Instance.OpenCloseBreakMenu(breakPanel);
        }
    }
}