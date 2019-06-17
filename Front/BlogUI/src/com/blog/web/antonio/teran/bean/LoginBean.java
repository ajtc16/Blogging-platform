package com.blog.web.antonio.teran.bean;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Map;

import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;

import com.blog.web.client.teran.bean.User;
import com.blog.web.client.teran.test.JavaWebApiApp;

@ManagedBean(name = "loginBean")
public class LoginBean {

	public String userName;
	public String password;
	
	private String url = "https://localhost:5001/api/blog/";
	
	JavaWebApiApp api = new JavaWebApiApp();
	User user = new User();
	 
	
	
	public void  validateUser() {
		
		
		System.out.println(userName+" "+password);
		user=new User();
		
		user=api.httpGet(url,  "userExist?username="+userName+"&password="+password);
		
		if (user.getUserID()!=0) {
		
		
			ExternalContext ec = FacesContext.getCurrentInstance().getExternalContext();
			try {
				 
				Map<String, Object> sessionMap = ec.getSessionMap();
				sessionMap.put("USERNAME", userName);
				sessionMap.put("USERID", user.getUserID());
				
				
				
			    ec.redirect(ec.getRequestContextPath()+ "/pages/post.xhtml");
			} catch (IOException e) {
			    // TODO Auto-generated catch block
			    e.printStackTrace();
			}
		} else {
			FacesContext context = FacesContext.getCurrentInstance();
	         
	        context.addMessage(null, new FacesMessage("Successful",  "Your message: bad user name or password" ) );
		}
		
		
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	public String getUserName() {
		return userName;
	}
	public void setUserName(String userName) {
		this.userName = userName;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	
	
	
	
	
	
	
}
