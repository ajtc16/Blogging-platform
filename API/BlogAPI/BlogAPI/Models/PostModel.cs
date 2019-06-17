using System;
namespace BlogAPI.Models
{
    public class PostModel
    {
        public int postID;
        public string text;
        public string dateCreated;
        public string dateModify;
        public int status;
        public int userID;
        public int active;




        public int getPostID()
        {
            return this.postID;
        }

        public void setPostID(int value)
        {
            this.postID = value;
        }


        public string getText()
        {
            return this.text;
        }

        public void setText(string value)
        {
            this.text = value;
        }




        public string getDateCreated()
        {
            return this.dateCreated;
        }

        public void setDateCreated(string value)
        {
            this.dateCreated = value;
        }



        public string getDateModify()
        {
            return this.dateModify;
        }

        public void setDateModify(string value)
        {
            this.dateModify = value;
        }



        public int getStatus()
        {
            return this.status;
        }

        public void setStatus(int value)
        {
            this.status = value;
        }

        public int getUserID()
        {
            return this.userID;
        }

        public void setUserID(int value)
        {
            this.userID = value;
        }

        public int getActive()
        {
            return this.active;
        }

        public void setActive(int value)
        {
            this.active = value;
        }


        
    }
}
