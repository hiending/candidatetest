using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter_CSV_to_TagBaseXML_from_TypeInfos
{
    /// <summary>
    /// Класс для хранения имени типа объекта и информации о тегах объекта
    /// </summary>
    public class TagType
    {
        public string nameType { get; set; }
        public Dictionary<string, string> propertiesTag;

        public TagType(string _nameType)
        {
            nameType = _nameType;
            propertiesTag = new Dictionary<string, string>();
        }

        public void addPropertiesTag(string _nameProp, string _valueType)
        {
            propertiesTag.Add(_nameProp, _valueType);
        }
    }
}
