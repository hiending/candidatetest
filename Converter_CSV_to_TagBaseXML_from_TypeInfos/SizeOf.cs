using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter_CSV_to_TagBaseXML_from_TypeInfos
{
    /// <summary>
    /// Статический класс с функцией, 
    /// которая определяет размер простого типа в байтах по строковому псевдониму-названию этого типа
    /// </summary>
    public static class SizeOf
    {
        public static int getSizeOfType(string _typeName)
        {
            switch (_typeName)
            {
                //Тип - логическое выражение
                case "bool": return 1;
                //Целочисленные типы
                case "sbyte": return 1;
                case "byte": return 1;
                case "short": return 2;
                case "ushort": return 2;
                case "int": return 4;
                case "uint": return 4;
                case "long": return 8;
                case "ulong": return 8;
                case "char": return 2;
                //Числовые типы с плавающей запятой 
                case "float": return 4;
                case "double": return 8;
                case "decimal": return 16;
                //если тип описан неверно, возвращаем 0
                default:    return 0;
            }    
        }
    }
}
