using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP.UnityWay
{
    public interface IUserProcessor
    {
        //可加特性
        void RegUser(User user);
        User GetUser(User user);
    }
}
