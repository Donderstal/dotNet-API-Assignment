using System.IO;
using System.Collections.Generic;

namespace XLSXReaderAPI.Services {
    public class XLSXReader {
        private bool FileIsSet { get; set; }
        private string FilePath { get; set; }
        private FileStream XLSXFile { get; set; }
        public XLSXReader( )
        {
            FileIsSet = false;
        }
        private void setFileToReader( string filePath )
        {
            FilePath = filePath;
            FileIsSet = true; 
        }
        private void unsetFileFromReader( )
        {
            FilePath = null;
            FileIsSet = false; 
        }
        public Dictionary<string, Dictionary<string, string>> mapExcelFileToDictionary(string filePath ) 
        {
            Dictionary<string, Dictionary<string, string>> mappedExcelFile = new Dictionary<string, Dictionary<string, string>>( );

            unsetFileFromReader( );
            setFileToReader( filePath );

            return mappedExcelFile;
        }
    }    
}
