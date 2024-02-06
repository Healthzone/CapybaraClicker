using UnityEngine;

namespace Assets.Scripts.ShopSystem
{
    public class ShopItemDataBase
    {
        public string ClickCost = "";
        public int ClickLevel = 1;

        public string Click2Cost = "";
        public int Click2Level = 1;

        public string Click3Cost = "";
        public int Click3Level = 1;

        public string Click4Cost = "";
        public int Click4Level = 1;

        public string AutoClickCost = "";
        public int AutoClickLevel = 1;

        public string AutoClick2Cost = "";
        public int AutoClick2Level = 1;

        public string AutoClick3Cost = "";
        public int AutoClick3Level = 1;

        public string AutoClick4Cost = "";
        public int AutoClick4Level = 1;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }

        public T GetFieldValue<T>(string name)
        {
            return (T)typeof(ShopItemDataBase).GetField(name).GetValue(this);
        }

        public void SetFieldValue<T>(string name, T value)
        {
            typeof(ShopItemDataBase).GetField(name).SetValue(this, value);
        }
    }
}
