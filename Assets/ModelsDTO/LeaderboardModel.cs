using UnityEngine;

namespace Assets.ModelsDTO
{
    internal class LeaderboardModel
    {
        public string Username;
        public long Score;

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
