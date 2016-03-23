using System.Runtime.Serialization;

namespace Items
{
    [DataContract]
    public class Item1
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string FirstName { get; set; }
    }
}
