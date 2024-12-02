using ContactsManagementDomain.Entities;
using Newtonsoft.Json;

namespace ContactsManagementInfra.JsonDataStore
{
    public class ContactsJsonDataStore
    {
        private const string FilePath = "Contacts.json";
        
        /// <summary>
        /// This Function is used to get all the data from JSON file.
        /// </summary>
        /// <returns>No request parameters reuired.</returns>
        public List<Contacts> GetAll()
        {
            if (!File.Exists(FilePath)) return new List<Contacts>();
            var jsonData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Contacts>>(jsonData) ?? new List<Contacts>();
        }

        /// <summary>
        /// This Function is used to save all the data into JSON file.
        /// </summary>
        /// <returns>List of type contact class will be accepted as input parameters.</returns>
        public void SaveAll(List<Contacts> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(FilePath, jsonData);
        }
    }
}
