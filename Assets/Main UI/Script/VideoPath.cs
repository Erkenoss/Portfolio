using UnityEngine;

public static class VideoPath
{
    #region Public Fields
    #endregion

    #region Private Fields
    #endregion

    #region MonoBehaviour Callbacks
    #endregion

    #region Public Methods

    public static string GetPath(string fileName)
    {
#if UNITY_EDITOR
        return System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

#else
        string baseURL = Application.absoluteURL;
        baseURL = baseURL.Substring(0, baseURL.LastIndexOf('/'));
        return baseURL + "/StreamingAssets/" + fileName;
#endif
    }

    #endregion

    #region Private Methods
    #endregion
}
