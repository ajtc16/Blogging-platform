using System;
namespace BlogAPI.Models
{
    public class CountryModel
    {
        public int nationalityID;
        public string countryName;
     



        public int getNationalityID()
        {
            return this.nationalityID;
        }

        public void setNationalityID(int value)
        {
            this.nationalityID = value;
        }


        public string getCountryName()
        {
            return this.countryName;
        }

        public void setCountryName(string value)
        {
            this.countryName = value;
        }


    }
}
