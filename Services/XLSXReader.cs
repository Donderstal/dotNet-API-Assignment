using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;

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

            return mapExcelSheets( ref mappedExcelFile );
        }
        public Dictionary<string, Dictionary<string, string>> mapExcelSheets( ref Dictionary<string, Dictionary<string, string>> mappedExcelFile ) 
        {
            using ( var package = new ExcelPackage( new FileInfo( FilePath )) ) {
                foreach ( var worksheet in package.Workbook.Worksheets )
                {
                    string worksheetKey = worksheet.Name;
                    mappedExcelFile.Add( worksheetKey, mapExcelTable( worksheet ) );
                }
            }
            return mappedExcelFile;
        }

        public Dictionary<string, string> mapExcelTable( ExcelWorksheet worksheet )
        {
            List<string> keyList = new List<string>( );
            Dictionary<string, string> mappedTable = new Dictionary<string, string>( );

            int columnsInSheet  = worksheet.Dimension.End.Column;
            int rowsInSheet     = worksheet.Dimension.End.Row;

            for (int currentRow = 1; currentRow <= rowsInSheet; currentRow++)
            {
                for (int currentColumn = 1; currentColumn <= columnsInSheet; currentColumn++)
                {
                    // do stuff
                }
            }
            return mappedTable;
        }
    }    
}
