﻿using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAds1 : MonoBehaviour
{
    // Serialize private fields
    //  instead of making them public.
    [SerializeField]
    string androidGameId;
    [SerializeField]
    bool enableTestMode;

    void Start()
    {
        string gameId = null;

        gameId = androidGameId;

        if (string.IsNullOrEmpty(gameId))
        { // Make sure the Game ID is set.
            Debug.LogError("Failed to initialize Unity Ads. Game ID is null or empty.");
        }
        else if (!Advertisement.isSupported)
        {
            Debug.LogWarning("Unable to initialize Unity Ads. Platform not supported.");
        }
        else if (Advertisement.isInitialized)
        {
            Debug.Log("Unity Ads is already initialized.");
        }
        else
        {
            Debug.Log(string.Format("Initialize Unity Ads using Game ID {0} with Test Mode {1}.",
                gameId, enableTestMode ? "enabled" : "disabled"));
            Advertisement.Initialize(gameId, enableTestMode);
        }
    }
}