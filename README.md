> 首先需要说明的一点是，本系列文章中涉及 **DotNetCore** 相关内容几乎没有，之所以这样命名是为了后续系列博客做技术储备，**杠精** 请出门右拐点击 *关闭* 按钮即可。其次，设计模式与语言无关，所以还请各位萌新不要陷入语言妄想症。

## 前言

关于什么是设计模式，这里简单描述描述一下：

> 所谓设计模式，是指软件开发人员在长时间的软件开发过程中通过对以往问题的总结和概括，并加以实践，设计出来的一套行之有效的解决方法。在恰当的时机使用合适的设计模式往往能事半功倍。同时也使整个项目结构清晰易懂。

设计模式代表了最佳实践。主张基于以下的面向对象设计原则：

- 对接口编程而不是对实现编程；
- 有限使用对象组合而不是继承；

同时，设计模式也具有以下六大原则：

- 开闭原则（Open Close Principle）
- 里氏代换原则（Liskov Substitution Principle）
- 依赖倒转原则（Dependence Inversion Principle）
- 接口隔离原则（Interface Segregation Principle）
- 迪米特法则，又称最少知道原则（Demeter Principle）
- 合成复用原则（Composite Reuse Principle）

## 系列博文

- 创建型模式
  - [简单工厂模式](https://www.cnblogs.com/hippieZhou/p/9938761.html)
  - [抽象工厂模式](https://www.cnblogs.com/hippieZhou/p/9939891.html)
  - [单例模式](https://www.cnblogs.com/hippieZhou/p/9940021.html)
  - [建造者模式](https://www.cnblogs.com/hippieZhou/p/9940354.html)
  - [原型模式](https://www.cnblogs.com/hippieZhou/p/9940504.html)

> 这些设计模式提供了一种在创建对象的同时隐藏创建逻辑的方式，而不是使用 *new* 运算符直接实例化对象。这使得程序在判断针对某个给定实例需要创建哪些对象时更加灵活。

- 结构型模式
  - [适配器模式](https://www.cnblogs.com/hippieZhou/p/9941684.html)
  - [桥接模式](https://www.cnblogs.com/hippieZhou/p/9942277.html)
  - [过滤器模式](https://www.cnblogs.com/hippieZhou/p/9965175.html)
  - [组合模式](https://www.cnblogs.com/hippieZhou/p/9972384.html)
  - [装饰器模式](https://www.cnblogs.com/hippieZhou/p/9979019.html)
  - [外观模式](https://www.cnblogs.com/hippieZhou/p/10016521.html)
  - [享元模式](https://www.cnblogs.com/hippieZhou/p/10017009.html)
  - [代理模式](https://www.cnblogs.com/hippieZhou/p/10055048.html)

> 这些设计模式关注类和对象的组合。继承的概念被用来组合接口和定义组合对象获得新功能的方式。

- 行为型模式
  - [责任链模式](https://www.cnblogs.com/hippieZhou/p/10055183.html)
  - [命令模式](https://www.cnblogs.com/hippieZhou/p/10067774.html)
  - [解释器模式](https://www.cnblogs.com/hippieZhou/p/10085500.html)
  - [迭代器模式](https://www.cnblogs.com/hippieZhou/p/10087250.html)
  - [中介者模式](https://www.cnblogs.com/hippieZhou/p/10087721.html)
  - [备忘录模式](https://www.cnblogs.com/hippieZhou/p/10093574.html)
  - [观察者模式](https://www.cnblogs.com/hippieZhou/p/10093772.html)

> 这些设计模式特别关注对象之间的通信。

下图整体描述了设计模式之间的关系

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181110112909986-39355182.jpg)

为了对设计模式进行重新的梳理认识，同时后期对 **DotNetCore** 系列进行进一步学习。所以这里我打算借助 **DotNetCore** 的进行相关的学习。并记录下来，方便各位感兴趣的朋友共同学习和指正。

## 相关参考

- [图说设计模式](https://design-patterns.readthedocs.io/zh_CN/latest/index.html)
- [设计模式](http://www.runoob.com/design-pattern/design-pattern-tutorial.html)