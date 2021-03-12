using System;
using System.Collections.Generic;
using System.Text;

namespace POApp.Interfaces
{
    public interface IPOService<T> where T: IPOTreeNodeValue
    {
        IMyTreeNode<T> GetMsgctxtTree(string fileName);
    }
}
