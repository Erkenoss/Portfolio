using Crimson.UI.But;
using UnityEngine;

namespace Crimson.Portfolio
{
    [CreateAssetMenu(fileName = "Back Button", menuName = "UI/Portfolio/Button/Back Button")]
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