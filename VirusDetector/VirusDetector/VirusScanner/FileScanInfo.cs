using System;

namespace VirusDetector.VirusScanner
{

    class FileScanInfo
    {
        String _pFileName;

        public String FileName
        {
            get { return _pFileName; }
            set { _pFileName = value; }
        }
        Boolean _pResult;

        public Boolean Result
        {
            get { return _pResult; }
            set { _pResult = value; }
        }

        public FileScanInfo()
        {
            _pFileName = null;
            _pResult = false;
        }

        public FileScanInfo(String pFileName, Boolean pResult)
        {
            _pFileName = pFileName;
            _pResult = pResult;
        }
    }
}
