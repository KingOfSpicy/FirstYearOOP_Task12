using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace OOP_CheWeiHsu_Task12
{
    [DataContract]
    class Client : IEquatable<Client>
    {
        public Client(int id, string firstName, string familyName, string telephoneNumber, string email, string preferredType, double maxRentPossible)
        {
            Id = id;
            FirstName = firstName;
            FamilyName = familyName;
            TelephoneNumber = telephoneNumber;
            Email = email;
            PreferredType = preferredType;
            MaxRentPossible = maxRentPossible;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string FamilyName { get; set; }
        [DataMember]
        public string TelephoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PreferredType { get; set; }
        [DataMember]
        public double MaxRentPossible { get; set; }

        //如果要從List刪除資料，我們必須在Client.cs裡加上GetHashCode
        public override bool Equals(object obj)
        {
            return Equals(obj as Client);
        }

        public bool Equals(Client other)
        {
            return other != null &&
                   Id == other.Id &&
                   FirstName == other.FirstName &&
                   FamilyName == other.FamilyName &&
                   TelephoneNumber == other.TelephoneNumber &&
                   Email == other.Email &&
                   PreferredType == other.PreferredType &&
                   MaxRentPossible == other.MaxRentPossible;
        }

        public override int GetHashCode()
        {
            var hashCode = 423733164;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FamilyName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TelephoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PreferredType);
            hashCode = hashCode * -1521134295 + MaxRentPossible.GetHashCode();
            return hashCode;
        }
    }
}
