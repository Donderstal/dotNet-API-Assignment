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
        public Dictionary<string, List<Dictionary<string, string>>> mapExcelFileToDictionary( string filePath ) 
        {
            Dictionary<string, List<Dictionary<string, string>>> mappedExcelFile = new Dictionary<string, List<Dictionary<string, string>>>( );

            unsetFileFromReader( );
            setFileToReader( filePath ); 

            return mapExcelSheets( ref mappedExcelFile );
        }
        public Dictionary<string, List<Dictionary<string, string>>> mapExcelSheets( ref Dictionary<string, List<Dictionary<string, string>>> mappedExcelFile ) 
        {
            using ( var package = new ExcelPackage( new FileInfo( FilePath )) ) {
                foreach ( var worksheet in package.Workbook.Worksheets )
                {
                    if ( worksheet.Dimension != null ) {
                        string worksheetKey = worksheet.Name;
                        mappedExcelFile.Add( worksheetKey, mapExcelTable( worksheet ) );
                    }
                }
            }
            return mappedExcelFile;
        }

        public List<Dictionary<string, string>> mapExcelTable( ExcelWorksheet worksheet )
        {
            List<string> keyList = new List<string>( );
            List<Dictionary<string, string>> mappedTableList = new List<Dictionary<string, string>>();
            Dictionary<string, string> mappedRow;

            int columnsInSheet  = worksheet.Dimension.End.Column;
            int rowsInSheet     = worksheet.Dimension.End.Row;

            for (int currentRow = 1; currentRow <= rowsInSheet; currentRow++)
            {
                mappedRow = new Dictionary<string, string>( );

                for (int currentColumn = 1; currentColumn <= columnsInSheet; currentColumn++)
                {
                    if ( currentRow == 1 ) {
                        keyList.Add( getTrimmedValueFromCell( worksheet, currentRow, currentColumn ) );
                    }
                    else {
                        mappedRow.Add( keyList[currentColumn - 1], getTrimmedValueFromCell( worksheet, currentRow, currentColumn ) );
                    }
                }

                if ( currentRow != 1 ) {
                    mappedTableList.Add(mappedRow);
                }
            }
            return mappedTableList;
        }

        public string getTrimmedValueFromCell( ExcelWorksheet worksheet, int row, int column ) 
        {
            return worksheet.Cells[row, column].Value?.ToString().Trim();
        }
    }    
}
