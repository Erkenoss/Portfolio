using Crimson.UI.Pagination;
using I2.Loc;
using UnityEngine;
using System.Collections.Generic;

namespace Crimson.Portfolio
{
    [CreateAssetMenu(fileName = "Model", menuName = "Portfolio/Model")]
    public class PortfolioModel : PageModel
    {
        #region Public Fields

        public EPanel Panel { get { return panel; } }
        public LocalizedString Description { get { return description; } }
        public List<VideoName> VideoList { get { return videoList; } }

        #endregion

        #region Private Fields

        [Tooltip("The panel rely on this PageModel")]
        [SerializeField]
        private EPanel panel = EPanel.None;

        [Tooltip("Description I2 loc key of the model")]
        [SerializeField]
        private LocalizedString description = null;

        [Tooltip("All video of this page")]
        [SerializeField]
        private List<VideoName> videoList = new List<VideoName>();

        #endregion

        #region MonoBehaviour Callbacks
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}