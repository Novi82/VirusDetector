using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDetector.VirusScanner
{

    class FileScanInfo
    {
        String _fileName;

        public String FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        Boolean _result;

        public Boolean Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public FileScanInfo()
        {
            _fileName = null;
            _result = false;
        }

        public FileScanInfo(String fileName_, Boolean result_)
        {
            _fileName = fileName_;
            _result = result_;
        }
    }
}
