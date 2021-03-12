using POApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POApp.Models
{
    class MyTreeNode<T>: IMyTreeNode<T> where T : IMyTreeNodeValue
    {
        private List<IMyTreeNode<T>> children = new List<IMyTreeNode<T>>();
        public T Value { get; set; }
        public IEnumerable<IMyTreeNode<T>> Children { get; private set; }

        public IMyTreeNode<T> Parent { get; private set; }

        public MyTreeNode(T value)
        {
            Children = children;
            Value = value;
        }

        public IMyTreeNode<T> AddChild(T value)
        {
            IMyTreeNode<T> node = new MyTreeNode<T>(value) { Parent = this };
            children.Add(node);
            return node;
        }

        public IMyTreeNode<T> FindInChildren(T value)
        {
            foreach (var node in Children)
            {
                if (node.Value.Name == value.Name)
                {
                    return node;
                }
            }
            return null;
        }
    }
}
