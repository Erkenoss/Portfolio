using UnityEngine;
using Crimson.UI.But;

namespace Crimson.Portfolio
{
    [CreateAssetMenu(fileName = "Switch Panel", menuName = "Portfolio/Button/Switch")]
    public class SwitchPanel : BaseButton
    {
        public override void Execute()
        {
            if (PortfolioUIManager.Instance == null)
            {
                return;
            }

            PortfolioUIManager.Instance.SetPanel();
        }
    }
}