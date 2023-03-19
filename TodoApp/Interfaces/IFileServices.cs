using System.Threading.Tasks;

namespace TodoApp.Interfaces
{
    /// <summary>Работа с файлами отчётов</summary>
    public interface IFileService
    {
        string AppFolder { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<string> OpenFile();

        /// <summary>
        /// Read file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<string> ReadFile(string name);

        /// <summary>
        /// Сохранение скаченного файла
        /// </summary>
        /// <param name="data">Тело отчёта</param>
        /// <param name="name">Имя файла</param>
        Task SaveFile( string name, string text);

        Task AddFolder(string Name);


        /// <summary>
        /// Метод отображения файла нативными средствами
        /// </summary>
        /// <param name="fileName">Имя файла, которого хотим показать</param>
        /// <param name="mimeType">Тип файла</param>
        void ViewFile(string fileName, string mimeType);

        void SelectFolder();

    }
}