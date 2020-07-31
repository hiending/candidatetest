using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Converter_CSV_to_TagBaseXML_from_TypeInfos
{
    /// <summary>
    /// Сохраняем сконвертированные данные в XML файл
    /// </summary>
    public class OutputXML
    {
        //создаем документ XML
        private XDocument xDoc = new XDocument();

        //Создаем корневой элемент
        private XElement root = new XElement("root");

        //создаем первый вложенный элемент
        private XElement item;

        //Добавление данных в элемент item
        public void addDataItem(string _tag, string _offset)
        {
            //Создаем атрибут
            XAttribute attr = new XAttribute("Binding", "Introduced");
            //создаем вложенный элемент 1
            XElement node_path = new XElement("node-path", _tag);
            //создаем вложенный элемент 2
            XElement address = new XElement("address", _offset);

            //переинициализируем item
            item = new XElement("item");

            //Добавляем атрибут и вложенные элементы
            item.Add(attr);
            item.Add(node_path);
            item.Add(address);

            //Добавим заполненный item в root
            root.Add(item);
        }

        //После заполнения всех item и добавления их в root можем добавить корневой элемент в xDoc
        public void addRootInDoc()
        {
            xDoc.Add(root);
        }

        //Сохраним XML документ
        public string saveDoc(string _nameFile)
        {   
            try
            {
                xDoc.Save(_nameFile);
                return null;
            }
            catch (System.IO.IOException e)
            {
                return e.Message;
            }
        }
    }
}
