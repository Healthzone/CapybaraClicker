using UnityEngine;
using YG;

public class LeaderboardGetter : MonoBehaviour
{
    [SerializeField] private string leaderboardName;
    [SerializeField] private int maxQuantityPlayer;
    [SerializeField] private int quantityTop;
    [SerializeField] private int quantityAround;
    [SerializeField] private string photoSizeLb;

    public void GetLeaderboardTop()
    {
        YandexGame.GetLeaderboard(leaderboardName, maxQuantityPlayer, quantityTop, quantityAround, photoSizeLb);
    }
}
