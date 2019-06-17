using System;
namespace BlogAPI.Models
{
    public class GenderModel
    {
		public int genderID;
		public string genderName;




		public int getGenderID()
		{
			return this.genderID;
		}

		public void setGenderID(int value)
		{
			this.genderID = value;
		}


		public string getGenderName()
		{
			return this.genderName;
		}

		public void setGenderName(string value)
		{
			this.genderName = value;
		}
	}
}
