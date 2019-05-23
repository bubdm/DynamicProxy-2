# DynamicProxy
实现AOP的多种方式：a 静态实现--装饰器/代理模式    b 动态实现--Remoting/Castle(Emit)      c 静态织入--PostSharp（收费）--扩展编译工具，生成的加入额外代码      d 依赖注入容器的AOP扩展(开发)      e MVC的Filter--特性标记，然后该方法执行前/后就多了逻辑    invoker调用中心--负责反射调用方法--检查特性--有则执行额外逻辑 
