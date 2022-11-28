using Gameboard;
using Gameboard.Objects.Ranking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameboardAnalytics : MonoBehaviour
{
    EngagementController engagementController;
    UserPresenceController userPresenceController;

    private List<RankingEntry> rankingEntries;

    private Guid reportId;

    public static GameboardAnalytics singleton;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
        {
            Destroy(this);
        }
        singleton = this;
        GameObject gameboardObject = GameObject.FindWithTag("Gameboard");
        engagementController = gameboardObject.GetComponent<EngagementController>();
        userPresenceController = gameboardObject.GetComponent<UserPresenceController>();

        rankingEntries = new List<RankingEntry>();
    }

    public void SendGameStart()
    {
        engagementController.SendUserIdsInSession(new List<string>(userPresenceController.Users.Keys));
    }

    public void SendGameEnd()
    {
        engagementController.SendGameSessionStarted(new List<string>(userPresenceController.Users.Keys));
    }
}
