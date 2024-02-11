using UnityEngine;

namespace Assets.Scripts.ShopSystem
{
    public class ShopItemDataBase
    {
        public string ClickCost = "";
        public int ClickLevel = 1;
        public bool isOpenedClick = false;

        public string Click2Cost = "";
        public int Click2Level = 1;
        public bool isOpenedClick2 = false;

        public string Click3Cost = "";
        public int Click3Level = 1;
        public bool isOpenedClick3 = false;

        public string Click4Cost = "";
        public int Click4Level = 1;
        public bool isOpenedClick4 = false;

        public string Click5Cost = "";
        public int Click5Level = 1;
        public bool isOpenedClick5 = false;

        public string Click6Cost = "";
        public int Click6Level = 1;
        public bool isOpenedClick6 = false;

        public string AutoClickCost = "";
        public int AutoClickLevel = 1;
        public bool isOpenedAutoClick = false;

        public string AutoClick2Cost = "";
        public int AutoClick2Level = 1;
        public bool isOpenedAutoClick2 = false;

        public string AutoClick3Cost = "";
        public int AutoClick3Level = 1;
        public bool isOpenedAutoClick3 = false;

        public string AutoClick4Cost = "";
        public int AutoClick4Level = 1;
        public bool isOpenedAutoClick4 = false;

        public string AutoClick5Cost = "";
        public int AutoClick5Level = 1;
        public bool isOpenedAutoClick5 = false;

        public string AutoClick6Cost = "";
        public int AutoClick6Level = 1;
        public bool isOpenedAutoClick6 = false;

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
