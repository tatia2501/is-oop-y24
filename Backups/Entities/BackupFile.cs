namespace Backups.Entities
{
    public class BackupFile
    {
        private string _name;
        private string _extension;
        private string _path;
        private string _fullName;
        public BackupFile(string fullPath)
        {
            _name = fullPath.Substring(fullPath.LastIndexOf('/'), fullPath.LastIndexOf('.') - fullPath.LastIndexOf('/'));
            _extension = fullPath.Substring(fullPath.LastIndexOf('.'));
            _path = fullPath.Substring(0, fullPath.LastIndexOf('/') - 1);
            _fullName = fullPath;
        }

        public string Name => _name;
        public string Extension => _extension;
        public string Path => _path;
        public string FullName => _fullName;
    }
}