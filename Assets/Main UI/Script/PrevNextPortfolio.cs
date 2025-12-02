using UnityEngine;
using Crimson.UI.Pagination;
using Crimson.UI;

namespace Crimson.Portfolio
{
    [CreateAssetMenu(fileName = "Next/Prev Button", menuName = "Portfolio/Button/PrevNext")]
    public class PrevNextPortfolio : PrevNext
    {
        #region Public Fields
        #endregion

        #region Private Fields
        #endregion

        #region MonoBehaviour Callbacks
        #endregion

        #region Public Methods

        public override void Execute()
        {
            if (UIManager<PortfolioModel>.Instance != null)
            {
                if (isPrev)
                {
                    UIManager<PortfolioModel>.Instance.Prev();
                }
                else
                {
                    UIManager<PortfolioModel>.Instance.Next();
                }
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}