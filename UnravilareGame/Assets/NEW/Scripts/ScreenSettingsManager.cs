using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettingsManager : MonoBehaviour
{
    [Header("ScreenSettings")]
    [SerializeField] TextMeshProUGUI resolutionText;
    [SerializeField] Toggle fullScreenToggle;
    private const string RESOLUTION_KEY = "Resolution";
    private int currentResIndex = 0;
    private Resolution[] resolutions;

    bool hasFullScreen;
    void Start()
    {
        resolutions = Screen.resolutions;
        hasFullScreen = Screen.fullScreen;
        currentResIndex = PlayerPrefs.GetInt(RESOLUTION_KEY,0);
        SetResolutionText(resolutions[currentResIndex]);
    }

    public void ApplySettings()
    {
        ApplyResolution(resolutions[currentResIndex]);
    }

    public void SetFullScreen()
    {
        if(fullScreenToggle.isOn) hasFullScreen = true;
        else hasFullScreen = false;
    }

    #region ResolutionChange

    private void SetResolutionText(Resolution resolution)
    {
        resolutionText.text = $"{resolution.width} x {resolution.height}";
    }
    public void SetNextResolution()
    {
        currentResIndex = GetNextIndex(resolutions, currentResIndex);
        SetResolutionText(resolutions[currentResIndex]);
    }
    public void SetPriviouseResolution()
    {
        currentResIndex = GetPreviousIndex(resolutions, currentResIndex);
        SetResolutionText(resolutions[currentResIndex]);
    }
    private int GetNextIndex<T>(IList<T> collection, int currenIndex)
    {
        if (collection.Count < 1) return 0;
        return (currenIndex + 1) % collection.Count;
    }
    private int GetPreviousIndex<T>(IList<T> collection, int currenIndex)
    {
        if (collection.Count < 1) return 0;
        if ((currenIndex - 1) < 0) return collection.Count - 1;
        return (currenIndex - 1) % collection.Count;
    }
    #endregion
    private void ApplyResolution(Resolution resolution)
    {
        SetResolutionText(resolution);
        Screen.SetResolution(resolution.width, resolution.height,hasFullScreen);
        PlayerPrefs.SetInt(RESOLUTION_KEY, currentResIndex);
    }

}
