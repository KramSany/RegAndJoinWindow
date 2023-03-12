using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace RegAndJoinWindow.Auth
{
    public class AuthData
    {
        private Dictionary<string, string> _authenticationData = new();
        public AuthData()
        {
            Load();
        }
        public static int Level { get; set; }

        public bool AddUser(string login, string password)
        {
            if (_authenticationData.ContainsKey(login))
            {
                MessageBox.Show($"Такой {login} уже есть, пожалуйста, сделайте новый логин");
                return false;
            }
            _authenticationData.Add(login, password);
            Save();
            return true;
        }
        public bool Authorization(string login, string password)
        {
            if (!_authenticationData.TryGetValue(login, out string result))
            {
                return false;
            }
            if (result != password)
            {
                MessageBox.Show($"Пароль от аккаунта {login} - неверный!");
                return false;
            }
            return true;
        }
        private void Save()
        {
            string json = JsonConvert.SerializeObject(_authenticationData, Formatting.Indented);
            File.WriteAllText(@"authenticationData.json", json);
        }
        private void Load()
        {
            if (!File.Exists(@"authenticationData.json"))
            {
                return;
            }
            string json = File.ReadAllText(@"authenticationData.json");
            _authenticationData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
        public void CheckRule(string login)
        {
            if (login == "admin") Level = 1;
            else Level = 0;
        }
    }
}
