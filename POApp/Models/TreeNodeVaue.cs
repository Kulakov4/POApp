using POApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POApp.Models
{
    public class TreeNodeVaue: IPOTreeNodeValue
    {
        public string Name { get; private set; }
        public IEnumerable<Translation> Translations { get; private set; }

        public TreeNodeVaue(string name)
        {
            Name = name;
            Translations = null;
        }

        public void AddTranslation(string msgid, string msgstr)
        {
            if (string.IsNullOrWhiteSpace(msgid))
                throw new ArgumentNullException(nameof(msgid));

            if (string.IsNullOrWhiteSpace(msgstr))
                throw new ArgumentNullException(nameof(msgstr));

            if (Translations == null)
                Translations = new List<Translation>();

            (Translations as List<Translation>).Add(new Translation { MsgId = msgid, MsgStr = msgstr });
        }
    }
}
