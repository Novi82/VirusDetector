using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDetector.StringCompare
{
    class FileInfo
    {
        String _fileName;

        public String FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        int _mark;

        public int Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }

        public FileInfo()
        {
            _fileName = "";
            _mark = Utils.Utils.BENIGN_MARK;
        }

        public FileInfo(String fileName_, int mark_)
        {
            _fileName = fileName_;
            _mark = mark_;
        }
    }
}
