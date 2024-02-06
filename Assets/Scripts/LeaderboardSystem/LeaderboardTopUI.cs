using UnityEngine;

public class LeaderboardTopUI : MonoBehaviour
{
    [SerializeField]
    private LeaderboardItemUI[] leaderboardItemUI;

    public void OnEnable()
    {
        GetLeaderboardTop();
    }

    private void GetLeaderboardTop()
    {

    }
}
