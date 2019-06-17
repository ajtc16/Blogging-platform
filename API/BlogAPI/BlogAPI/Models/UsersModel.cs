using System;
namespace BlogAPI.Models
{
    public class UsersModel
    {
        public int userID;
        public string userName;
        public string password;
        public string status;



        public int getUserID()
        {
            return this.userID;
        }

        public void setUserID(int value)
        {
            this.userID = value;
        }


        public string getUserName()
        {
            return this.userName;
        }

        public void setUserName(string value)
        {
            this.userName = value;
        }


        public string getPassword()
        {
            return this.password;
        }

        public void setPassword(string value)
        {
            this.password = value;
        }


        public string getStatus()
        {
            return this.status;
        }

        public void setStatus(string value)
        {
            this.status = value;
        }





    }
}
