using System;
using System.Runtime.Serialization;

namespace PhoneBook.Core.Model
{
    [DataContract]
    public partial class Card
    {
        [CardDisplay("Prénom", 100, 1)]
        [DataMember]
        public string FirstName { get; set; }

        [CardDisplay("Nom", 100, 2)]
        [DataMember]
        public string LastName { get; set; }

        [CardDisplay("N° Int.", 75, 3)]
        [DataMember]
        public string InternalPhoneNumber { get; set; }

        [CardDisplay("N° Ext", 100, 4)]
        [DataMember]
        public string ExternalPhoneNumber { get; set; }

        [CardDisplay("Service", 100, 5)]
        [DataMember]
        public string Department { get; set; }

        [CardDisplay("Poste", 200, 6)]
        [DataMember]
        public string Job { get; set; }
    }
}
