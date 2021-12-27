using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public static class ObjectExtensionClass
    {
        public static string Name(this string filePath)
        {
            return ObjectManager.RemovePathFromName(filePath);
        }

        public static string FileSize(this string filePath)
        {
            long answer = ObjectManager.GetSizeOfFile(filePath);
            return Utilities.FileSizeFormat(answer);
        }

        public static string FolderSize(this string folderPath)
        {
            long answer = ObjectManager.GetSizeOfDirectory(folderPath);
            return Utilities.FileSizeFormat(answer);
        }

        public static string LastAccess(this string path)
        {
            return ObjectManager.GetTimeStampForLastAccess(path);
        }
    }
}
