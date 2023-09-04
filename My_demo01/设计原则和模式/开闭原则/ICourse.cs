using System;
using System.Collections.Generic;
using System.Text;

namespace 设计原则和模式.开闭原则
{
    /// <summary>
    /// 开闭原则定义：一个软件实体，如： 类，模块，函数，应该对扩展开放，对修改关闭，用抽象构建框架，用实现扩展细节
    /// 优点：提高软件的可复用性 以及 可维护性
    /// 
    /// 示例：课程接口，Name和ID不会变，但是Price会改变
    /// 首先有一门课程CS，实现该接口ICourse，但是后面价格会变动，再用一个类去继承课程类CS
    /// </summary>
    public interface ICourse
    {
        string GetName();
        double GetPrice();
        string GetID();

    }

}
