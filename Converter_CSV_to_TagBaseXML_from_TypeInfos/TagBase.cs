using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter_CSV_to_TagBaseXML_from_TypeInfos
{
    /// <summary>
    /// Подготовленная база одного объекта
    /// </summary>
    public class TagBase
    {
        public string nameTagBase { get; set; }
        //массив с подготовленной базой тегов
        public List<SingleTag> preparedTagBase = new List<SingleTag>();

        //Добавить тег в последовательность
        public void addTagSequence(SingleTag _tag)
        {
            preparedTagBase.Add(_tag);
        }
    }

    /// <summary>
    /// Формат выходной ячейки
    /// </summary>
    public class SingleTag
    {
        public string tag { get; set; }
        public string offset { get; set; }

        public SingleTag(string _tag, string _offset)
        {
            tag = _tag;
            offset = _offset;
        }
    }
}
