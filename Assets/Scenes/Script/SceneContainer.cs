using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "Scene Container", menuName = "Scene/Scene Container")]
public class SceneContainer : ScriptableObject
{
    #region Public Fields

    public SceneFieldList SceneList { get { return sceneList; } }

    /// <summary>
    /// List of our differente scene
    /// </summary>
    [System.Serializable]
    public class SceneFieldList
    {
        public List<SceneField> SceneFields { get { return sceneFields; } }

        /// <summary>
        /// List of our scene
        /// </summary>
        [SerializeField]
        private List<SceneField> sceneFields = new List<SceneField>();
    }

    /// <summary>
    /// One scene
    /// </summary>
    [System.Serializable]
    public class SceneField
    {
        public AssetReference SceneReference { get { return sceneReference; } }

        /// <summary>
        /// Reference of the scene here
        /// </summary>
        [SerializeField]
        private AssetReference sceneReference = null;
    }

    #endregion

    #region Private Fields

    /// <summary>
    /// List of scene
    /// </summary>
    [SerializeField]
    private SceneFieldList sceneList = new SceneFieldList();

    #endregion

    #region MonoBehaviour Callbacks
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
