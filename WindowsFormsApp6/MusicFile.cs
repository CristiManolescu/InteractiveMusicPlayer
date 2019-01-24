using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class MusicFile
    {
        public int ID = -1;

        private string m_fileName = "";
        public string FileName
        {
            get { return m_fileName; }
            set
            {
                m_fileName = value;
                if (m_fileName.Contains(".") && m_fileName.Contains("/"))
                {
                    // from FTP (/)
                    string _pathWithoutFolder = m_fileName.Split('/')[m_fileName.Split('/').Length - 1];
                    m_safeFileName = _pathWithoutFolder.Replace("." + _pathWithoutFolder.Split('.')[_pathWithoutFolder.Split('.').Length - 1], "");
                }
                else
                {
                    if (m_fileName.Contains(".") && m_fileName.Contains("\\"))
                    {
                        // from personal computer (\)
                        string _pathWithoutFolder = m_fileName.Split('\\')[m_fileName.Split('\\').Length - 1];
                        m_safeFileName = _pathWithoutFolder.Replace("." + _pathWithoutFolder.Split('.')[_pathWithoutFolder.Split('.').Length - 1], "");
                    }
                }

            }
        }

        private string m_safeFileName = "";
        public string SafeFileName
        {
            get { return m_safeFileName; }
            set { m_safeFileName = value; }
        }


        public MusicFile(int _dbID, string _dbFileName)
        {
            FileName = _dbFileName;
            ID = _dbID;
        }

    }
}
