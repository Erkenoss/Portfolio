using Crimson.UI.But;
using UnityEngine;

namespace Crimson.Portfolio
{
    [CreateAssetMenu(fileName = "Back Button", menuName = "Portfolio/Button/Back Button")]
    public class BackButton : BaseButton
    {
        public override void Execute()
        {
            if (PortfolioUIManager.Instance == null)
            {
                return;
            }

            PortfolioUIManager.Instance.Back();
        }
    }
}