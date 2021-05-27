using System;
using System.Collections.Generic;
using System.IO;

namespace ControleMatricula
{
    public static class FileUtil
    {
        public static void Save(string fileName, string path, List<string> lstContent)
        {
            try
            {
                var fullPath = $@"{path}\{fileName}";                
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    for (int i = 0; i < lstContent.Count; i++)
                    {
                        sw.WriteLine(lstContent[i]);
                    }               
                }                
            }
            catch (Exception ex)
            {
                throw new MissingFieldException(ex.ToString());
            }
        }

        public static List<string> Read(string fileName, string path)
        {
            try
            {
                var fullPath = $@"{path}\{fileName}";                
                using (StreamReader sr = File.OpenText(fullPath))
                {
                    List<string> lst = new List<string>();
                    string s = string.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        lst.Add(s);
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new MissingFieldException(ex.ToString());
            }
        }

        public static void Delete(string fileName, string path)
        {
            try
            {
                var fullPath = $@"{path}\{fileName}";                
                File.Delete(fullPath);
            }
            catch (Exception ex)
            {
                throw new MissingFieldException(ex.ToString());
            }   
        }
    }
}
