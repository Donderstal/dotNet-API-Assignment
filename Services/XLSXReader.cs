using Microsoft.AspNetCore.Http;

namespace XLSXReaderAPI.Services {
    public class XLSXReader {
        private bool FileIsSet { get; set; }
        private string FilePath { get; set; }
        private IFormFile XLSXFile { get; set; }
        public XLSXReader( )
        {
            FileIsSet = false;
        }
        private void setFileToReader( IFormFile file, string filePath )
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
    }    
}
