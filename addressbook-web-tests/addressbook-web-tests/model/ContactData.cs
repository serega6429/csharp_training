using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
		private string allPhones;
		private string allMails;
		private string fullContactInfo;
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "id"), PrimaryKey]
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
		public string DetailsContactInfo{ get; set; }
		public string Image { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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

        public ContactData() { }

		private string GetFullInfo()
		{
			string fullInfo = "";
			List<string> list = new List<string>()
			{
				(Firstname + " " + MidlName + " " + Lastname).Replace("  ", " ").Trim(),
				NickName,
				Title,
				Company,
				Address,
				"\r\n",
				"H: " + HomePhone,
				"M: " + MobilePhone,
				"W: " + WorkPhone,
				"F: " + Fax,
				"\r\n",
				Email,
				Email2,
				Email3,
				"Homepage:\r\n" + HomePage,
				"\r\n",
				"Birthday " + (BDay != "0" ? BDay + ". " : "") + BMounth + AddAge(BYear),
				"Anniversary " + (ADay != "0" ? ADay + ". " : "") + AMounth + AddAge(AYear),
				 "\r\n",
				Address2,
				"\r\n",
				"P: " + Phome2,
				"\r\n",
				Notes
			};

			for (int i = list.Count - 1; i >= 0; i--)
			{

				if (list[i] != "") 
				{
					if ((list[i] != "F: ") && (list[i] != "P: ") && (list[i] != "W: ") && (list[i] != "M: ") && (list[i] != "H: "))
					{
						if ((list[i] != "Birthday -") && (list[i] != "Anniversary -") && (list[i] != "Homepage:\r\n"))  
						{
							if (list[i] != "\r\n")
							{   
								fullInfo = list[i] + (fullInfo.Length == 0 ? "" : "\r\n") + fullInfo;
							} else
							{
								if (fullInfo.Length != 0)
								{
									fullInfo = list[i] + fullInfo;
								}
							}
						}
					}
				}
				
			}
			while (fullInfo.Contains("\r\n\r\n\r\n"))
			{
				fullInfo = fullInfo.Replace("\r\n\r\n\r\n", "\r\n\r\n");
			}
			return fullInfo;
		}

		private string AddAge(string text)
		{
			if ((text != "") && (text != null))
			{
				string curentYear = DateTime.Now.Year.ToString();
				return " " + text + " (" + (Int32.Parse(curentYear) - Int32.Parse(text)) + ")";
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
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where
                        (x => x.Deprecated == "0000-00-00 00:00:00")  select g).ToList();
            }
        }
    }
}
