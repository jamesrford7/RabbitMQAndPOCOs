using System.Runtime.Serialization;

namespace Items
{
    [DataContract]
    public class Item2
    {
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Poo { get; set; }
    }
}
