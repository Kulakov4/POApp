using POApp.Interfaces;
using POApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POApp.Services
{
    public class POFileService : IPOService<IPOTreeNodeValue>
    {
        public IMyTreeNode<IPOTreeNodeValue> GetMsgctxtTree(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));

            var currentContext = "";
            var currentMsgId = "";
            var currentMsgStr = "";

            var msgctxt = "msgctxt ";
            var msgid = "msgid ";
            var msgstr = "msgstr ";

            IPOTreeNodeValue rv = new TreeNodeVaue("root");
            var mtnv = new MyTreeNode<IPOTreeNodeValue>(rv);

            IMyTreeNode<IPOTreeNodeValue> root = new MyTreeNode<IPOTreeNodeValue>(new TreeNodeVaue("root"));
            var node = root;
            IPOTreeNodeValue nodeValue = null;
            using (var file = new StreamReader(fileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine().Trim();

                    if (string.IsNullOrEmpty(line) || line.StartsWith("#"))
                        continue;

                    if (line.StartsWith(msgctxt, StringComparison.OrdinalIgnoreCase))
                    {
                        // запоминаем текущий контекст
                        currentContext = line.Substring(msgctxt.Length).Trim(' ', '"');
                        var m = currentContext.Split('.');
                        node = root;
                        foreach (var s in m)
                        {
                            nodeValue = new TreeNodeVaue(s);

                            // Ищем узел
                            var newNode = node.FindInChildren(nodeValue);
                            if (newNode != null)
                            {
                                nodeValue = newNode.Value;
                            }
                            else 
                            {
                                newNode = node.AddChild(nodeValue);
                            }
                            node = newNode;
                        }
                        continue;
                    }

                    if (line.StartsWith(msgid, StringComparison.OrdinalIgnoreCase))
                    {
                        currentMsgId = line.Substring(msgid.Length).Trim(' ', '"');
                        continue;
                    }

                    if (line.StartsWith(msgstr, StringComparison.OrdinalIgnoreCase))
                    {
                        currentMsgStr = line.Substring(msgstr.Length).Trim(' ', '"');

                        if (currentMsgId == "")
                            throw new Exception("MsgId not found");

                        if (currentMsgStr == "")
                            throw new Exception("MsgStr not found");

                        if (nodeValue == null)
                        {
                            nodeValue = new TreeNodeVaue("Без контекста");
                            node = node.AddChild(nodeValue);
                        }

                        nodeValue.AddTranslation(currentMsgId, currentMsgStr);

                        currentMsgId = "";
                        currentMsgStr = "";
                        continue;
                    }
                }
            }

            return root;
        }
    }
}
