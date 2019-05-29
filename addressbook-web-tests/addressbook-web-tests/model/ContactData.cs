using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
		private string allPhones;

		public string Firstname { get; set; }
        public string Lastname { get; set; }
		public string Id { get; set; }
		public string Address { get; set; }
		public string HomePhone { get; set; }
		public string MobilePhone { get; set; }
		public string Email { get; set; }
		public string Email2 { get; set; }
		public string Email3 { get; set; }
		public string WorkPhone { get; set; }
		public string allMails {
			get
			{
				if(allMails != null)
				{
					return allMails;
				}
				else
				{
					return (Email + Email2 + Email3).Trim();
				}
			}
			set
			{
				allMails = value;
			}
		}
		public string AllPhones {
			get
			{
				if (allPhones != null)
				{
					return allPhones;
				}
				else
				{
					return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
				}
			}
			set
			{
				allPhones = value;
			}
		}

		private string CleanUp(string phone)
		{
			if(phone == null || phone == "")
			{
				return "";
			}
			return phone.Replace(" ", "").Replace("-", "").
				Replace("(", "").Replace(")", "") + "\r\n";
		}

		public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (!(Firstname.Equals(other.Firstname)))
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return ((Firstname == other.Firstname) && (Lastname == other.Lastname));
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "Contact: " + Firstname + " " + Lastname;
        }
    }
}
