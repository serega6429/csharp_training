using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
		private string allPhones;
		private string allMails;
		private string fullContactInfo;

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
		public string MidlName { get; internal set; }
		public string NickName { get; internal set; }
		public string Notes { get; internal set; }
		public string Phome2 { get; internal set; }
		public string Address2 { get; internal set; }
		public string AYear { get; internal set; }
		public string AMounth { get; internal set; }
		public string ADay { get; internal set; }
		public string BYear { get; internal set; }
		public string BMounth { get; internal set; }
		public string BDay { get; internal set; }
		public string HomePage { get; internal set; }
		public string Fax { get; internal set; }
		public string Title { get; internal set; }
		public string Company { get; internal set; }

		public string FullContactInfo
		{
			get
			{
				if (fullContactInfo != null)
				{
					return fullContactInfo;
				}
				else
				{
					return 
				}
			}
			set
			{
				fullContactInfo = value;
			}
		}
		public string AllMails
		{
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
			return Regex.Replace(phone, "[ -()]", "") + "\r\n";
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
