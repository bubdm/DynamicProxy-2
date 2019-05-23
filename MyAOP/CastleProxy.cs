using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using static LoggingInterceptor;

namespace MyAOP
{
   public class CastleProxy
    {
        public static void show()
        {
            DependencyResolver.Initialize();

            //resolve the type:Rocket
            var rocket = DependencyResolver.For<IRocket>();

            //method call
            try
            {
                rocket.Launch(5);
            }
            catch (Exception ex)
            {

            }
            System.Console.ReadKey();
        }
    }
    }

    public class Rocket : IRocket
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public void Launch(int delaySeconds)
        {

            Console.WriteLine(string.Format("Launching rocket in {0} seconds", delaySeconds));
            Thread.Sleep(1000 * delaySeconds);
            Console.WriteLine("Congratulations! You have successfully launched the rocket");
        }
    }
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            try
            {
                Console.WriteLine(string.Format("Entered Method:{0}, Arguments: {1}", methodName, string.Join(",", invocation.Arguments)));
                invocation.Proceed();
                Console.WriteLine(string.Format("Sucessfully executed method:{0}", methodName));
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Method:{0}, Exception:{1}", methodName, e.Message));
                throw;
            }
            finally
            {
                Console.WriteLine(string.Format("Exiting Method:{0}", methodName));
            }
        }

        public class ComponentRegistration : IRegistration
        {
            public void Register(IKernelInternal kernel)
            {
                kernel.Register(
                    Component.For<LoggingInterceptor>()
                        .ImplementedBy<LoggingInterceptor>());

                kernel.Register(
                    Component.For<IRocket>()
                             .ImplementedBy<Rocket>()
                             .Interceptors(InterceptorReference.ForType<LoggingInterceptor>()).Anywhere);
            }
        }
        public interface IRocket
        {
            void Launch(int delaySeconds);
        }
        public class DependencyResolver
        {
            private static IWindsorContainer _container;

            //Initialize the container
            public static void Initialize()
            {
                _container = new WindsorContainer();
                _container.Register(new ComponentRegistration());
            }

            //Resolve types
            public static T For<T>()
            {
                return _container.Resolve<T>();
            }
        }
    }
