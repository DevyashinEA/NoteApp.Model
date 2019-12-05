using System.IO;
using Newtonsoft.Json;
namespace NoteApp.Model
{
    /// <summary>
    /// Класс Сериализации, с помощью которого выполняется загрузка/выгрузка информации в формате JSON.
    /// </summary>
    public static class ProjectManager
    {
        public static void Serializer(Project project)
        {
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(@"c:\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
        }
        public static Project Deserializer()
        {
            //Создаём переменную, в которую поместим результат десериализации
            Project project = null;
        //Создаём экземпляр сериализатора
        JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            try
            {
                using (StreamReader sr = new StreamReader(@"c:\json.txt"))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                    project = (Project)serializer.Deserialize<Project>(reader);
                }
                return project;
            }
            catch
            {
                return new Project();
            }
        }
    }
}