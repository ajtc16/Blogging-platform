package com.blog.web.client.teran.test;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;

import javax.xml.ws.Response;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClientBuilder;
import org.apache.http.util.EntityUtils;

import com.blog.web.client.teran.bean.User;
import com.blog.web.client.teran.bean.Post;

public class JavaWebApiApp {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
//		System.setProperty("javax.net.ssl.trustStore", "/Users/antonio/Desktop/localhost.crt");
		
		 String url = "https://localhost:5001/api/blog/";

//		    httpGet(url, "userExist?username=ajtc16&password=antonio1");
//		 httpGet1(url, "recoverOwnerPosts?idUser=1");
		 Post p = new Post();
		 p.setPostID(9);
		 p.setText("Prueba de update desde post");
		 p.setStatus(1);
		 p.setUserID(1);
		 p.setActive(0);
		 
//		 {"text":"este es mi segundo Post publico","status":2,"userID":1,"active":0}
		 
//		 httpPostActionPost(url, "insertPost", p);
//		 httpPostActionPost(url, "updatePost", p);
//		 httpPostActionPost(url, "deletePost", p);
	}

	public   User httpGet(String url, String function) {

		User response = new User();
		try (CloseableHttpClient httpClient = HttpClientBuilder.create()
				.build()) {
			HttpGet request = new HttpGet(url + function);
			request.addHeader("content-type", "application/json");

			HttpResponse result = httpClient.execute(request);
			String json = EntityUtils.toString(result.getEntity(), "UTF-8");

			com.google.gson.Gson gson = new com.google.gson.Gson();
			
			 response = gson.fromJson(json, User.class);
//			User[] response = gson.fromJson(json, User[].class);

			System.out.println(response);

		} catch (IOException ex) {
			ex.printStackTrace();
		}
		return response;
	}
	
	
	public  ArrayList<Post> httpGetPosts(String url, String function) {

		ArrayList<Post> dataFromService = new ArrayList<Post>();
		try (CloseableHttpClient httpClient = HttpClientBuilder.create()
				.build()) {
			HttpGet request = new HttpGet(url + function);
			request.addHeader("content-type", "application/json");

			HttpResponse result = httpClient.execute(request);
			String json = EntityUtils.toString(result.getEntity(), "UTF-8");

			com.google.gson.Gson gson = new com.google.gson.Gson();
			
			
			Post[] response = gson.fromJson(json, Post[].class);

			System.out.println(response.length);
			for (Post file : response) {
				dataFromService.add(file);
				
				System.out.println(file.toString());
			}

		} catch (IOException ex) {
			ex.printStackTrace();
		}
		return dataFromService;
	}
	
	
	public void httpPostActionPost(String url, String function , Post postParam) {
		
		String       postUrl       = url;// put in your url
		com.google.gson.Gson         gson          = new com.google.gson.Gson();
		HttpClient   httpClient    = HttpClientBuilder.create().build();
		HttpPost     post          = new HttpPost(postUrl+function);
		StringEntity postingString=null;
		try {
			postingString = new StringEntity(gson.toJson(postParam));//gson.tojson() converts your pojo to json
		
		post.setEntity(postingString);
		post.setHeader("Content-type", "application/json");
		HttpResponse  response = httpClient.execute(post);
		}catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
	}
	
	
	
	
	

}
