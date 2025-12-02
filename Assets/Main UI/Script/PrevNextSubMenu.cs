using Crimson.Portfolio;
using Crimson.UI.Pagination;
using UnityEngine;

[CreateAssetMenu(fileName = "Prev/Next Sub Menu", menuName = "Portfolio/Button/PrevNext/SubMenu")]
public class PrevNextSubMenu : PrevNext
{
    [Tooltip("Panel where this button action is")]
    [SerializeField]
    private EPanel panel = EPanel.None;

    public override void Execute()
    {
        if (UIManager<PortfolioModel>.Instance != null)
        {
            UIManager<PortfolioModel>.Instance.SubPanelNavigation(isPrev, panel);
        }
    }
}
