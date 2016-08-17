using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    public string zoneId;
    public int rewardQty = 250;

    void OnGUI()
    {
        if (string.IsNullOrEmpty(zoneId)) zoneId = null;

        Rect buttonRect = new Rect(10, 10, 300, 150); //modified the size of the rect so that it is easier to see and interact with

        string buttonText = Advertisement.IsReady(zoneId) ? "Show Ad" : "Waiting...";

        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        if (GUI.Button(buttonRect, buttonText))
        {
            Advertisement.Show(zoneId, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Video completed. User rewarded " + rewardQty + " credits.");
                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Video was skipped.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                break;
        }
    }
}