using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity;
using Unity.Interception.PolicyInjection.Policies;//InterceptionExtension

namespace MyAOP.UnityWay
{
    /// <summary>
    /// 
    /// 使用EntLib\PIAB Unity 实现动态代理
    /// 
    /// </summary>
    public class UnityConfigAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Eleven",
                Password = "1234567890123456789"
            };

            IUserProcessor processor = UnityFactory.Instance.ICreateContainer().Resolve<IUserProcessor>();
            processor.RegUser(user);
            //processor.GetUser(user);
        }
    }
}
