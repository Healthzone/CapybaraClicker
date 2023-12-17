using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ModelsDTO
{
    [Serializable]
    public class LeaderboardsTop : IEnumerable<User>
    {
        public LeaderboardsTop(List<User> users)
        {
            Users = users;
        }
        public List<User> Users;

        public IEnumerator<User> GetEnumerator()
        {
            return Users.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    [Serializable]
    public class User
    {
        public User(string username, long score)
        {
            Username = username;
            Score = score;
        }
        public string Username;
        public long Score;

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
