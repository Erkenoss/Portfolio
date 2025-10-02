using Crimson.UI.Pagination;
using I2.Loc;
using UnityEngine;

namespace Crimson.Portfolio
{
    [CreateAssetMenu(fileName = "Model", menuName = "Portfolio/Model")]
    public class PortfolioModel : PageModel
    {
        #region Public Fields

        public EPanel Panel { get { return panel; } }
        public LocalizedString Description { get { return description; } }

        #endregion

        #region Private Fields

        [Tooltip("The panel rely on this PageModel")]
        [SerializeField]
        private EPanel panel = EPanel.None;

        [Tooltip("Description I2 loc key of the model")]
        [SerializeField]
        private LocalizedString description = null;

        #endregion

        #region MonoBehaviour Callbacks
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}