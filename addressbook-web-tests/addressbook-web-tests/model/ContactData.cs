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
		private string detailsContactInfo;

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
		public string MidlName { get; set; }
		public string NickName { get; set; }
		public string Notes { get; set; }
		public string Phome2 { get; set; }
		public string Address2 { get; set; }
		public string AYear { get; set; }
		public string AMounth { get; set; }
		public string ADay { get; set; }
		public string BYear { get; set; }
		public string BMounth { get; set; }
		public string BDay { get; set; }
		public string HomePage { get; set; }
		public string Fax { get; set; }
		public string Title { get; set; }
		public string Company { get; set; }
		public string DetailsContactInfo
		{
			get
			{
				return detailsContactInfo.Replace("\r", "").
					Replace("\n", "").Replace("M:", "").Replace("H:", "").
					Replace("W:", "").Replace("F:", "").Replace("P:", "").
					Replace("Homepage:","").Replace("Birthday", "").
					Replace("Anniversary", "")
					.Replace(" ", "");
			}
			set
			{
				detailsContactInfo = value;
			}
		}

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
					return GetFullInfo();
				}
			}
			set
			{
				fullContactInfo = value;
			}
		}

		private string GetFullInfo()
		{
			string fullInfo = Firstname + MidlName + Lastname + NickName +
			Title + Company + Address + HomePhone + MobilePhone + WorkPhone + 
			Fax + Email + Email2 + Email3 + HomePage + (BDay != "0" ? BDay + "." : "") + BMounth + 
			AddAge(BYear) + (ADay != "0" ? ADay + "." : "") + AMounth + AddAge(AYear) + Address2 + Phome2 + Notes;
			
			return Regex.Replace(fullInfo, "[ -]", "");
		}


		private string AddAge(string text)
		{
			if (!(text == ""))
			{
				string curentYear = DateTime.Now.Year.ToString();
				return text + "(" + (Int32.Parse(curentYear) - Int32.Parse(text)) + ")";
			}
			else
			{
				return text;
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
					return (CleanUpMail(Email) + CleanUpMail(Email2)
						+ CleanUpMail(Email3)).Trim();
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
					return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone)
						+ CleanUpPhone(WorkPhone)).Trim();
				}
			}
			set
			{
				allPhones = value;
			}
		}


		private string CleanUpMail(string mail)
		{
			if (mail == null || mail == "")
			{
				return "";
			}
			return mail + "\r\n";
		}

		private string CleanUpPhone(string phone)
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
