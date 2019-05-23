using MyAOP.UnityWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 1 AOP面向切面编程
    /// 2 静态代理实现AOP
    /// 3 动态代理实现AOP
    /// 4 Unity、MVC中的AOP
    /// 
    /// 
    /// AOP面向切面编程
    /// 
    /// POP面向过程编程：符合逻辑思维，线性的处理问题-----无法应付复杂的系统
    /// OOP面向对象编程：万物皆对象，对象交互完成功能，功能叠加成模块，模块组成系统，去搭建复杂的大型软件系统
    ///   砖块儿----墙---房间----大厦          砖块儿应该是稳定的，静态的
    ///       类----功能点---模块----系统      
    ///       类却是会变化的，增加日志/异常/权限/缓存/事务，只能修改类？
    ///       GOF的23种设计模式，应对变化，核心套路是依赖抽象，细节就可以变化
    ///       
    ///  但是只能替换整个对象，但是没办法把一个类动态改变    
    /// 
    /// AOP(Aspect):允许开发者动态的修改静态的OO模型，就像现实生活中对象在生命周期中会不断的改变自身。    
    /// AOP是一种编程思想，是OOP思想的补充
    /// 
    /// 正是因为能够动态的扩展功能，所以在程序设计时就可以有以下好处：
    /// 1 聚焦核心业务逻辑，权限/异常/日志/缓存/事务， 通用功能可以通过AOP方式添加，程序设计简单，
    /// 2 功能动态扩展；集中管理,代码复用;规范化；
    /// 
    /// 实现AOP的多种方式：
    /// a 静态实现--装饰器/代理模式
    /// b 动态实现--Remoting/Castle(Emit)
    /// c 静态织入--PostSharp（收费）--扩展编译工具，生成的加入额外代码
    /// d 依赖注入容器的AOP扩展(开发)
    /// e MVC的Filter--特性标记，然后该方法执行前/后就多了逻辑
    ///   invoker调用中心--负责反射调用方法--检查特性--有则执行额外逻辑
    /// 
    /// MVC的filter的AOP实现原理
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("面向切面AOP");

                #region AOP show
                //Console.WriteLine("************DecoratorAOP***********");
                //DecoratorAOP.Show();

                //Console.WriteLine("************ProxyAOP***********");
                //ProxyAOP.Show();

                //Console.WriteLine("************RealProxyAOP***********");
                //RealProxyAOP.Show();

                //Console.WriteLine("************CastleProxyAOP***********");
                CastleProxyAOP.Show();

                //Console.WriteLine("************UnityAOP***********");
                //UnityAOP.Show();

                UnityConfigAOP.Show();
                //1 顺序问题，配置文件的注册顺序是调用顺序，然后才是业务方法，但扩展逻辑可以在业务方法后；
                //2 接口方法不需要某个AOP扩展-a判断方法b推荐用特性(接口声明用特性，input.Target.GetType().GetCustomAttributes())
                //3 配置可以简写
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
