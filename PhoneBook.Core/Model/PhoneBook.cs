using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PhoneBook.Core.Model
{
    public class PhoneBook
    {
        public List<Card> Cards { get; }

        public PhoneBook()
        {
            Cards = new List<Card>();
        }

        public PhoneBook(string path)
        {
            Cards = GetCardsFromJSon(path);
        }

        private static List<Card> GetCardsFromJSon(string dataPath)
        {
            var json = new JavaScriptSerializer();
            return json.Deserialize<List<Card>>(File.ReadAllText(dataPath));
        }

        internal void SaveToJson(string jsonFormattedDataPath)
        {
            using (var file = File.CreateText(jsonFormattedDataPath))
            {
                var json = new JavaScriptSerializer().Serialize(Cards);
                file.Write(json);
            }
        }
    }
}
