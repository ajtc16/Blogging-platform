using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        GenericDataBaseController dbController = new GenericDataBaseController();

        //----------------USERS--------------
        [HttpGet]
        [Route("userExist")]
        public UsersModel Get(string username, string password)
        {
            UsersModel usersModel = new UsersModel();
            string[] user = new string[3];
             
            user = dbController.UserExist(username, password);

            if (string.IsNullOrEmpty(username))
            {
                usersModel.setUserID(0);
                return usersModel;
            }else if (username == user[1].ToString())
            {

                usersModel.setUserID(Int32.Parse(user[0].ToString()));
                usersModel.setUserName(user[1].ToString());
                usersModel.setPassword(user[2].ToString());

            }
                
   
            return usersModel;

        }


        [HttpPost]
        [Route("insertUser")]
        public void Post1([FromBody] UsersModel userModel)
        {
            bool inserted = false;

            inserted = dbController.InsertUser(userModel);


        }

        [HttpPost]
        [Route("updateUserPassword")]
        public void Post2([FromBody] UsersModel userModel)
        {
            bool updated = false;

            updated = dbController.UpdateUserPassword(userModel);


        }


        [HttpPost]
        [Route("deleteUser")]
        public void Post3([FromBody] UsersModel userModel)
        {
            bool deleted = false;

            deleted = dbController.DeleteUser(userModel);

        }


        //----------------POSTS---------------
        [HttpGet]
        [Route("recoverPosts")]
        public System.Collections.ArrayList GetPosts(String postType)
        {

            ArrayList publicposts = new ArrayList();

            if (postType == "public")
            {
                publicposts = dbController.recoverPublicPost();
            }


            return publicposts;

        }



        [HttpPost]
        [Route("insertPost")]
        public void Post4([FromBody] PostModel postModel)
        {
            bool inserted = false;

            inserted = dbController.InsertPost(postModel);

        }

        [HttpPost]
        [Route("updatePost")]
        public void Post5([FromBody] PostModel postModel)
        {
            bool inserted = false;

            inserted = dbController.UpdatePost(postModel);

        }


        [HttpPost]
        [Route("deletePost")]
        public void Post6([FromBody] PostModel postModel)
        {
            bool inserted = false;

            inserted = dbController.DeletePost(postModel);

        }

        [HttpGet]
        [Route("recoverOwnerPosts")]
        public System.Collections.ArrayList GetOwnerPosts(int idUser)
        {

            ArrayList publicposts = new ArrayList();

            
                publicposts = dbController.recoverOwnerPost(idUser);
           


            return publicposts;

        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
