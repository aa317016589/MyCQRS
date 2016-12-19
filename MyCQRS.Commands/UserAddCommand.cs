using System;

namespace MyCQRS.Commands
{
    public class UserAddCommand : Command
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        public UserAddCommand(Guid id, Int32 version, String userName) : base(id, version)
        {
            UserName = userName;
        }
    }
}