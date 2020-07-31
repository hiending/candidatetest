using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Xml.Linq;

namespace Converter_CSV_to_TagBaseXML_from_TypeInfos
{
    /// <summary>
    /// Класс с описанием логики обработки входных и выходных данным
    /// </summary>
    public class Logics
    {
        //объявим перечень тегов, хранящихся в TypeInfos
        public List<TagType> arrTagType;
        //объявим входные данные
        public List<InputData> arrInput;
        //выбранные входные данные
        private List<InputData> SelectedInputData;
        //Массив выходных данных
        public List<TagBase> arrOutputData;



        System.Windows.Forms.Form mainForm;

        //Флаг - прочитан файл TypeInfos
        public bool FlagRead_TypeInfos { get; set; } = false;
        //Флаг - прочитан файл Input
        public bool FlagRead_Input{ get; set; } = false;

        //в конструктор передадим главную форму для взаимодействия
        public Logics(System.Windows.Forms.Form _form)
        {
            mainForm = _form;
        }


        //Метод для обрабокти файла с типами объектов TypeInfos
        public bool readFile_TypeInfos()
        {
            //откроем диалог для выбора необходимого файла
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "Файлы JSON (*.json)|*.json";

            if (opfd.ShowDialog(mainForm) == DialogResult.OK)
            {
                //объявим документ JSON с которым будем работать
                JsonDocument jsonDoc;

                try
                {
                    //откроем поток из файла JSON указанного в диалоге
                    using (FileStream fs = File.OpenRead(opfd.FileName))
                    {
                        //ловим исключения, но не будем расшифровывать
                        //усливимся, если что-то пошло не так, значит файл не годится

                        //инициализируем документ функцией парсинга потока файла
                        jsonDoc = JsonDocument.Parse(fs);
                        //возьмем корневой элемент структуры нашего JSON файла
                        JsonElement root = jsonDoc.RootElement;

                        //Первый элемент в файле JSON для данной задачи должен начинаться с Объекта
                        //Удостоверимся в этом, иначе файл считается неверного формата
                        if (root.ValueKind != JsonValueKind.Object)
                        {
                            //поставим флаг о том что считывание завершилось неудачей
                            return false;
                        }

                        //берем перечислитель и идем далее
                        JsonElement.ObjectEnumerator obEn = root.EnumerateObject();
                        obEn.MoveNext();

                        //проверим, что название класса соответсвует структуре данного JSON документа
                        if (obEn.Current.Name != "TypeInfos")
                        {
                            //поставим флаг о том что считывание завершилось неудачей
                            return false;
                        }

                        //Получим значения внутри объекта TypeInfos
                        var groupsTags = obEn.Current.Value;

                        //проверим что следующий элемент в файле JSON - массив
                        //в этом массиве содержится требуемое описание типов тегов
                        if (groupsTags.ValueKind != JsonValueKind.Array)
                        {
                            //поставим флаг о том что считывание завершилось неудачей
                            return false;
                        }
                        else
                        {
                            //Инициализируем массив с тегами
                            arrTagType = new List<TagType>();


                            for (int i = 0; i < groupsTags.GetArrayLength(); i++)
                            {
                                JsonElement theGroup = groupsTags[i];
                                JsonElement.ObjectEnumerator obE_TypeName_and_Properties = theGroup.EnumerateObject();

                                //Первый шаг - Имя
                                obE_TypeName_and_Properties.MoveNext();

                                var nameVar1 = obE_TypeName_and_Properties.Current.Name;
                                var value_TargetNameType = obE_TypeName_and_Properties.Current.Value;

                                //на этом этапе мы можем получить имя "целевого типа объекта из файла"
                                //инициализируем врмененный TagType с названием TypeName
                                var tempTagType = new TagType(value_TargetNameType.ToString());



                                //Второй шаг - Свойства
                                obE_TypeName_and_Properties.MoveNext();

                                //получим значние следующего поля и получим его перечислитель
                                var propertiesInfo = obE_TypeName_and_Properties.Current.Value;
                                JsonElement.ObjectEnumerator obE_PropertiesInfo = propertiesInfo.EnumerateObject();

                                //Первый шаг для свойств
                                bool hasNext = obE_PropertiesInfo.MoveNext();

                                //пробежимся по коллекции свойств
                                while (hasNext)
                                {
                                    string tagName = obE_PropertiesInfo.Current.Name;
                                    string tagType = obE_PropertiesInfo.Current.Value.ToString();

                                    //каждое новое свойство поместим во временный tempTagType
                                    tempTagType.addPropertiesTag(tagName, tagType);

                                    hasNext = obE_PropertiesInfo.MoveNext();
                                }

                                //Добавим элемент в массив TagType
                                arrTagType.Add(tempTagType);
                            }
                        }

                    }
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        //Метод для считывания файла Input.csv 
        public bool readFile_InputCSV()
        {
            //откроем диалог для выбора необходимого файла CSV
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "Файлы CSV (*.csv)|*.csv";

            if (opfd.ShowDialog(mainForm) == DialogResult.OK)
            {
                //получим список объектов из файла
                arrInput = readLinesFormCSV(opfd.FileName);

                //Проверим удачное чтение
                if (arrInput != null)
                {
                    //проверим, что заголовки в файле CSV соответствуют заданным
                    if (arrInput[0].Tag == "Tag" && arrInput[0].Type == "Type" && arrInput[0].Address == "Address")
                    {
                        //В первой строке содержаться заголовки полей, удалим эти данные из нашего списка объектов
                        arrInput.RemoveAt(0);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Чтение CSV файла по строкам
        public List<InputData> readLinesFormCSV(string fileName)
        {
            var list = new List<InputData>();

            try
            {
                var lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    var cells = line.Split(';');
                    var item = new InputData();

                    if (cells.Length == 3)
                    {
                        item.Tag = cells[0];
                        item.Type = cells[1];
                        item.Address = cells[2];
                    }
                    else
                    {
                        return null;
                    }

                    list.Add(item);
                }
            }
            catch 
            {
                return null;
            }
            
            return list;
        }

        //Сформируем массив выбранных входных данных
        public void takeSelectedData(System.Windows.Forms.DataGridView _DGV_SelectedData, Color _clr)
        {
            //счетчик количества выделенных элементов в таблице
            int countSelectData = 0; 

            SelectedInputData = new List<InputData>();

            for (int i = 0; i < _DGV_SelectedData.Rows.Count; i++)
            {
                if (_DGV_SelectedData[0, i].Style.BackColor == _clr)
                {
                    countSelectData++;

                    InputData tempInputData = new InputData();

                    tempInputData.Tag = _DGV_SelectedData[1, i].Value.ToString();
                    tempInputData.Type = _DGV_SelectedData[2, i].Value.ToString();
                    tempInputData.Address = _DGV_SelectedData[3, i].Value.ToString();

                    SelectedInputData.Add(tempInputData);
                }
            }

            if (countSelectData == 0)
            {
                MessageBox.Show("Выберите хотябы один элемент из таблицы", "Внимание!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Соединение входых данных и данных о типе объекта
        public void getAssociation()
        {
            //инициализируем массив выходных данных
            arrOutputData = new List<TagBase>();

            if (SelectedInputData.Count > 0)
            {
                for (int i = 0; i < SelectedInputData.Count; i++)
                {
 
                    //получим индекс типа объекта для соединения
                    int typeIndex = arrTagType.FindIndex(x => x.nameType.Contains(SelectedInputData[i].Type));

                    if (typeIndex == -1)
                    {
                        break; //если такой тег не описан, пропускаем этот объект
                    }

                    //инициализируем смещение
                    int offset = 0;

                    //Составим базу одного объекта
                    TagBase tagBase_oneObject = new TagBase();
                    //Установим имя объекта
                    tagBase_oneObject.nameTagBase = SelectedInputData[i].Tag;

                    //пробежимся по свойствам соединенного объекта
                    //составим выходной массив
                    foreach (var selected_propertiesTag in arrTagType[typeIndex].propertiesTag)
                    {
                        //создадим один тег
                        SingleTag singleTag = new SingleTag(SelectedInputData[i].Tag + "." + selected_propertiesTag.Key, offset.ToString());
                        //сместим на размер типа данных
                        offset += SizeOf.getSizeOfType(selected_propertiesTag.Value);

                        tagBase_oneObject.addTagSequence(singleTag);
                    }

                    arrOutputData.Add(tagBase_oneObject);
                }
            }
        }

        //сохраним выходные данные
        public void saveOutputData()
        {
            if (arrOutputData != null && arrOutputData.Count > 0)
            {
                foreach (var outputData_tagBase_oneObject in arrOutputData)
                {
                    OutputXML outFile = new OutputXML();

                    foreach (var oneTag in outputData_tagBase_oneObject.preparedTagBase)
                    {
                        outFile.addDataItem(oneTag.tag, oneTag.offset);
                    }

                    outFile.addRootInDoc();

                    string strMessage = outFile.saveDoc(outputData_tagBase_oneObject.nameTagBase + ".xml");

                    if (strMessage != null)
                    {
                        MessageBox.Show(strMessage, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }

        }

    }





}
