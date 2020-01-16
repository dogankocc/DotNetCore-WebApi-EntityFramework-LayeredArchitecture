using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.UserModels;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DijitalTestApi.Controllers
{
    [Route("/[controller]")]
    public class UserTestController : Controller
    {

        private readonly IUserService userService;

        public UserTestController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return userService.GetUsers();
            //return userService.GetAll(); //for using IRepository<User> repository; in UserService class
        }
        /*
         *  @model IEnumerable<Model.UserModels>
           @{
                ViewBag.Title = "Users";
            }

            <h2>Users</h2>

            <p>
                <a asp-controller="UserTest" asp-action="CreateUser">Create New</a>
            </p>

            <table class="table">
                <tr>
                    <th>Name</th>
                    <th>Permissions</th>
                </tr>

                @foreach (var item in Model)
                {
                    <tr>
                        <td>
                            @Html.DisplayFor(modelItem => item.Name)
                        </td>
                        
                          @foreach (var p in item.UserPermissions)
                          {
                            <td>
                                @Html.DisplayFor(modelItem => p.Type)
                            </td>
                          }
                           
                        
                    </tr>
                }
            </table> 
        */

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public User Get(long id)
        {
            return userService.GetUser(id);
        }

        // POST /<controller>
        [HttpPost]
        public void CreateUser([FromBody]User user)
        {
            userService.CreateUser(user);
        }

        /***View Post request Example
            @model IEnumerable<Model.UserModels>
            @{
                ViewBag.Title = "New User";
            }

            <h2>@ViewData["User"]</h2>

            <form asp-controller="UserTest" asp-action="CreateUser" method="post" class="form-horizontal" role="form">
                <div class="form-horizontal">
                    <div asp-validation-summary="All" class="text-danger"></div>
                    <div class="form-group">
                        <label asp-for="Url" class="col-md-2 control-label"></label>
                        <div class="col-md-10">
                            <input asp-for="Url" class="form-control" />
                            <span asp-validation-for="Url" class="text-danger"></span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" value="CreateUser" class="btn btn-default" />
                        </div>
                    </div>
                </div>
            </form>
        */

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            userService.DeleteUser(id);
        }

        public class UserRequest
        {
            private string name;
            private int permissionType;

            public UserRequest(string name ,int permission) 
            {
                Name = name; PermissionType = permission;
            }
            public string Name { get => name; set => name = value; }
            public int PermissionType { get => permissionType; set => permissionType = value; }
        }
    }
}
