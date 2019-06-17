package com.blog.web.client.teran.bean;

public class Post {

	
	  public int postID;
      public String text;
      public String dateCreated;
      public String dateModify;
      public int status;
      public String status2;
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


      public String getText()
      {
          return this.text;
      }

      public void setText(String value)
      {
          this.text = value;
      }




      public String getDateCreated()
      {
          return this.dateCreated;
      }

      public void setDateCreated(String value)
      {
          this.dateCreated = value;
      }



      public String getDateModify()
      {
          return this.dateModify;
      }

      public void setDateModify(String value)
      {
          this.dateModify = value;
      }


      public String getStatus2()
      {
    	  if (this.status==0) {
    		  this.status2="Draft";
		} else if (this.status==1) {
			 this.status2="Private";
		}else if (this.status==2) {
			 this.status2="Public";
		}
    	  
    	  
          return this.status2;
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
