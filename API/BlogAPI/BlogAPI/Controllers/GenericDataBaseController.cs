using System;
using System.Collections;
using BlogAPI.Models;
using MySql.Data.MySqlClient;

namespace BlogAPI.Controllers
{
    public class GenericDataBaseController
    {
        static MySqlConnection con;

        public void Connect()//(string user, string password)
        {
            con = new MySqlConnection();
            try
            {
                con.ConnectionString = "server = localhost; User Id = root; " +
                    "Persist Security Info = True; database = blog_platform; Password = root";//+ password;
                con.Open();
                Console.WriteLine("Succesfully connected to DataBase Blog_Platform!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Not Successful! due to :" + e.ToString());
            }
        }

        public void Close()
        {
            try
            {
                con.Close();
                Console.WriteLine("Succesfully Closed Connection to DataBase Blog_Platform!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Not Successful! due to :" + e.ToString());
            }
        }


        public String[] UserExist(String userName, String Password)
        {
            String[] user = new string[3]; 
           
            try
            {
                Connect();
                string sql = "SELECT userid, username, password FROM user WHERE userName='" + userName + "' AND Password='" + Password + "' AND Status='A'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    user[0] = rdr[0].ToString();
                    user[1] = rdr[1].ToString();
                    user[2] = rdr[2].ToString();

                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                    break;
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" +ex.ToString());
            }
            finally
            {
                Close();
            }


            return user;
        }


        public bool InsertUser(UsersModel userModel)//String userName, String password)
        {
            bool inserted = false;
            try
            {
                Connect();
                string sql = "INSERT INTO User (UserName, Password, status) VALUES ('" + userModel.getUserName() + "', '" + userModel.getPassword() + "','A');";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" + ex.ToString());
                inserted = false;
            }
            finally
            {
                Close();
            }
            Console.WriteLine("Done. Insert");
            return inserted;
        }


        public bool UpdateUserPassword(UsersModel userModel)//String userName, String password)
        {
            bool update = false;
            try
            {
                Connect();
                string sql = "UPDATE USER SET Password = '" + userModel.getPassword() + "' WHERE UserName='" + userModel.getUserName() + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                update = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" + ex.ToString());
                update = false;
            }
            finally
            {
                Close();
            }
            Console.WriteLine("Done. Update");
            return update;
        }


        public bool DeleteUser(UsersModel userModel)
        {
            bool update = false;
            try
            {
                Connect();
                string sql = "UPDATE USER SET status = 'D' WHERE UserName='" + userModel.getUserName() + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                update = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" + ex.ToString());
                update = false;
            }
            finally
            {
                Close();
            }
            Console.WriteLine("Done. Logical Delete");
            return update;
        }






        public bool InsertPost( PostModel post)// String text, DateTime dateCreated, DateTime dateModify, int status, int userId)
        {
            bool inserted = false;
            try
            {
                Connect();

               post.setDateCreated(DateTime.Now.ToString("yyyy-M-dd").ToString());
                post.setDateModify(DateTime.Now.ToString("yyyy-M-dd").ToString());

                string sql = "INSERT INTO Post ( Text, DateCreated, DateModify, Status, UserID, active) VALUES('" + post.getText() + "', '" + post.getDateCreated() + "', '" + post.getDateModify() + "', " + post.getStatus() + ", " + post.getUserID() + ",0);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" + ex.ToString());
                inserted = false;
            }
            finally
            {
                Close();
            }
            Console.WriteLine("Done. Insert");
            return inserted;
        }


        public bool UpdatePost(PostModel post )//String text, DateTime dateModify, int status, int userId)
        {
            bool update = false;
            try
            {
                Connect();
                post.setDateModify(DateTime.Now.ToString("yyyy-M-dd").ToString());
                string sql = "UPDATE Post SET Text = '" + post.getText() + "', DateModify='"+ post.getDateModify() + "' ,Status="+ post.getStatus() + " WHERE UserID='" + post.getUserID() + "' and postID="+post.getPostID();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                update = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" + ex.ToString());
                update = false;
            }
            finally
            {
                Close();
            }
            Console.WriteLine("Done. Update");
            return update;
        }

        public bool DeletePost(PostModel post)//DateTime dateModify, int userId, int postId)
        {
            bool update = false;
            try
            {
                Connect();
                post.setDateModify(DateTime.Now.ToString("yyyy-M-dd").ToString());
                string sql = "UPDATE Post SET DateModify='" + post.getDateModify() + "' ,active=1 WHERE UserID='" + post.getUserID() + "' and postID="+ post.getPostID() ;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                update = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" + ex.ToString());
                update = false;
            }
            finally
            {
                Close();
            }
            Console.WriteLine("Done. Update");
            return update;
        }




        public ArrayList recoverPublicPost()
        {
            PostModel post = null;
            ArrayList postList = new ArrayList();

            try
            {
                Connect();
                string sql = "SELECT PostID, Text, DateCreated, DateModify , Status,UserID,Active FROM post WHERE Active=0 AND Status=2 order by DateCreated DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    post = new PostModel();

                    post.setPostID((int)rdr[0]);
                    post.setText(rdr[1].ToString());
                    post.setDateCreated(rdr[2].ToString());
                    post.setDateModify(rdr[3].ToString());

                    post.setStatus((int)rdr[4]);
                    post.setUserID((int)rdr[5]);
                    post.setActive((int)rdr[6]);

                    postList.Add(post);
                    

                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + " -- " + rdr[3] + " -- " + rdr[4] + " -- " + rdr[5] + " -- " + rdr[6]);
                    
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" + ex.ToString());
            }
            finally
            {
                Close();
            }


            return postList;
        }


        public ArrayList recoverOwnerPost(int idUser)
        {
            PostModel post = null;
            ArrayList postList = new ArrayList();

            try
            {
                Connect();
                string sql = "SELECT PostID, Text, DateCreated, DateModify , Status,UserID,Active FROM post WHERE UserID="+idUser+ " and Active=0 AND Status in (0,1) order by DateCreated DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    post = new PostModel();

                    post.setPostID((int)rdr[0]);
                    post.setText(rdr[1].ToString());
                    post.setDateCreated(rdr[2].ToString());
                    post.setDateModify(rdr[3].ToString());

                    post.setStatus((int)rdr[4]);
                    post.setUserID((int)rdr[5]);
                    post.setActive((int)rdr[6]);

                    postList.Add(post);


                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + " -- " + rdr[3] + " -- " + rdr[4] + " -- " + rdr[5] + " -- " + rdr[6]);
                   
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Successful! due to :" + ex.ToString());
            }
            finally
            {
                Close();
            }


            return postList;
        }



    }
}
