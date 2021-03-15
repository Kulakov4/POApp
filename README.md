На языке программирования C# разработать приложение Windows, отображающее файлы формата *.po 
(https://en.wikipedia.org/wiki/Gettext) в виде древовидной структуры. 

Иерархия дерева строится на основе полей "контекста" (msgctxt), разделение контекста на уровни 
выполняется с помощью символа "точка" ("."). 

Цель приложения - показать все существующие в файле контексты и принадлежащие им переводы.

Пример.

#: utils/gatestyletreewidget.c:132
msgid "Text style|Normal"
msgstr "običan"

#: skycomponents/constellationlines.cpp:106
#, kde-format
msgid "No star named %1 found."
msgstr "Nema zvezde po imenu %1."

#: utils/katestyletreewidget.cpp:132
msgctxt "Text style"
msgid "Normal"
msgstr "običan"
⁠
#: utils/kateautoindent.cpp:78
msgctxt "Autoindent mode"
msgid "Normal"
msgstr "obično"


msgctxt "Context1.Subcontext1.Subcontext2"
msgid "qwerty"
msgstr "ytrewq"

msgid "poiuy"
msgstr "yuiop"


msgctxt "Context1.Subcontext1"
msgid "asdfg"
msgstr "gfdsa"

msgid "test"
msgstr "tset"
