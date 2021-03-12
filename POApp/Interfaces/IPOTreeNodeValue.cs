using POApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POApp.Interfaces
{
    public interface IPOTreeNodeValue: IMyTreeNodeValue
    {
        IEnumerable<Translation> Translations { get; }
        void AddTranslation(string msgid, string msgstr);
    }
}
