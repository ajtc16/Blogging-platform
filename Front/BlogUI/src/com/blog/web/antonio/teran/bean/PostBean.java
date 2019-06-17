package com.blog.web.antonio.teran.bean;

import java.util.ArrayList;
import java.util.Map;

import javax.faces.bean.ManagedBean;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;

import com.blog.web.client.teran.bean.Post;
import com.blog.web.client.teran.test.JavaWebApiApp;

@ManagedBean(name = "postBean")
public class PostBean {

	public int postID;
    public String text;
    public String dateCreated;
    public String dateModify;
    public int status;
    public int userID=0;
    public int active;
    
    public  String name;
    
    private String url = "https://localhost:5001/api/blog/";
    
    JavaWebApiApp api = new JavaWebApiApp();
    Post post = new Post();
    ArrayList<Post> postList = new ArrayList<Post>();
    
  

    
    public PostBean() {
		super();
		initialize();
	}
    
    public void initialize() {
    	
    	postList = new ArrayList<Post>();
    	ExternalContext ec = FacesContext.getCurrentInstance().getExternalContext();
    	Map<String, Object> sessionMap = ec.getSessionMap();
    	 this.userID = 0;
		try {
			this.userID = (Integer) sessionMap.get("USERID");
		name= (String) sessionMap.get("USERNAME");
		}catch (Exception e) {
			userID=0;
		}
    	if (userID!=0) {
    		postList = api.httpGetPosts(url,  "recoverOwnerPosts?idUser="+this.userID);
    		postList.addAll(api.httpGetPosts(url,  "recoverPosts?postType=public"));
		}else {
			name="Public User";
			postList = api.httpGetPosts(url,  "recoverPosts?postType=public");
		}

    }
    
    public void createPost() {
    	try {
    		Post p = new Post();
    		ExternalContext ec = FacesContext.getCurrentInstance().getExternalContext();
        	Map<String, Object> sessionMap = ec.getSessionMap();
    		p.setText(text);
    		p.setUserID((Integer) sessionMap.get("USERID"));
    		p.setStatus(status);
    		System.out.println("before update");
    		api.httpPostActionPost(url, "insertPost", p);
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
    	initialize();
    	
    }
    
    public void updatePost() {
    	try {
    		System.out.println("before update");
        	api.httpPostActionPost(url, "updatePost", this.post);
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
    	initialize();
    	
    	
    }
    
    public void deletePost() {
    	
    	try {
    		System.out.println("before update");
    		api.httpPostActionPost(url, "deletePost", this.post);
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
    	initialize();
    	
    	
    }
    
    
public void columnRefresh() {
	text="";
}
    
    
    
    
	public int getPostID() {
		return postID;
	}
	public void setPostID(int postID) {
		this.postID = postID;
	}
	public String getText() {
		return text;
	}
	public void setText(String text) {
		this.text = text;
	}
	public String getDateCreated() {
		return dateCreated;
	}
	public void setDateCreated(String dateCreated) {
		this.dateCreated = dateCreated;
	}
	public String getDateModify() {
		return dateModify;
	}
	public void setDateModify(String dateModify) {
		this.dateModify = dateModify;
	}
	public int getStatus() {
		return status;
	}
	public void setStatus(int status) {
		this.status = status;
	}
	public int getUserID() {
		return userID;
	}
	public void setUserID(int userID) {
		this.userID = userID;
	}
	public int getActive() {
		return active;
	}
	public void setActive(int active) {
		this.active = active;
	}

	public Post getPost() {
		return post;
	}

	public void setPost(Post post) {
		this.post = post;
	}

	public ArrayList<Post> getPostList() {
		return postList;
	}

	public void setPostList(ArrayList<Post> postList) {
		this.postList = postList;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
	
	
	
}
