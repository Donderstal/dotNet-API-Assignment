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
        private void setFileToReader( FileStream file, string filePath )
        {
            XLSXFile = file;
            FilePath = filePath;
            FileIsSet = true; 
        }
        private void unsetFileFromReader( )
        {
            XLSXFile = null;
            FilePath = null;
            FileIsSet = false; 
        }
        public Dictionary<string, Dictionary<string, string>> mapExcelFileToDictionary( FileStream file, string filePath ) 
        {
            Dictionary<string, Dictionary<string, string>> mappedExcelFile = new Dictionary<string, Dictionary<string, string>>( );

            unsetFileFromReader( );
            setFileToReader( file, filePath );

            return mappedExcelFile;
        }
    }    
}
