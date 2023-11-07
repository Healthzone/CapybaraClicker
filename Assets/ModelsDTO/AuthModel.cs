using UnityEngine;

namespace Assets.ModelsDTO
{
    internal class AuthModel
    {
        public string Username;
        public string Password;
        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
