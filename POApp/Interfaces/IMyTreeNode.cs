using System;
using System.Collections.Generic;
using System.Text;

namespace POApp.Interfaces
{
    public interface IMyTreeNode<T> where T : IMyTreeNodeValue
    {
        T Value { get; set; }
        IEnumerable<IMyTreeNode<T>> Children { get; }

        IMyTreeNode<T> Parent { get; }

        IMyTreeNode<T> AddChild(T value);
        IMyTreeNode<T> FindInChildren(T value);
    }
}
