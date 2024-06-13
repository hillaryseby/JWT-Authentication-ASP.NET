using JWTAuthentication.DataTransferObjects;
using JWTAuthentication.Interface;

namespace JWTAuthentication.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        public static List<UserDataDto> usersDetails = new List<UserDataDto>();
        //{ new UserDataDto {
        //    UserName = "hsebastian" ,
        //    Age = 24,
        //    CourseEnrolled = "Computer Science",
        //    Address = "707 Douglas Street"

        //},
        //    new UserDataDto
        //    {
        //         UserName = "myName",
        //         Age = 24,
        //         CourseEnrolled = "Social Work",
        //         Address = "59 mark street"
        //    },
        //    new UserDataDto
        //    {
        //        UserName = "YoutName",
        //        Age = 30,
        //        CourseEnrolled = "IT",
        //        Address = "37 sutton place"
        //    }
        //};

        public async Task AddUserData(UserDataDto user)
        {
            await Task.Run(() =>             // this enables this code block to run asynchronousely
            {
                usersDetails.Add(new UserDataDto
                {
                    UserName = user.UserName,
                    Age = user.Age,
                    Address = user.Address,
                    CourseEnrolled = user.CourseEnrolled,
                });
            });

        }

        public async Task<List<UserDataDto>> GetUser()
        {
            return await Task.Run(() =>
            {
                return usersDetails.Select(user => new UserDataDto
                {
                    UserName = user.UserName,
                    Age = user.Age,
                    Address = user.Address,
                    CourseEnrolled = user.CourseEnrolled,
                }).ToList();
            });
        }

    }
}
