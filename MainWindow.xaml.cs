using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using System.Windows;
using Syncfusion.UI.Xaml.Grid.Converter;
using Microsoft.Win32;
using System.IO;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SfDataGridToPdfConverterExt customPDF;
        public MainWindow()
        {
            InitializeComponent();
            customPDF = new SfDataGridToPdfConverterExt();
        }         

        private void btnExportToPDF_Click(object sender, RoutedEventArgs e)
        {
            PdfExportingOptions options = new PdfExportingOptions();
            options.AutoColumnWidth = false;
            options.FitAllColumnsInOnePage = false;     
           
            //call the custom pdf Exporting 
            var document = customPDF.ExportToPdf(sfDataGrid,options);

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files(*.pdf)|*.pdf"
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    document.Save(stream);
                }

                //Message box confirmation to view the created Pdf file.

                if (MessageBox.Show("Do you want to view the Pdf file?", "Pdf file has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {

                    //Launching the Pdf file using the default Application.
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }        
    }      

    public class SfDataGridToPdfConverterExt : SfDataGridToPdfConverter
    { 
        public override PdfDocument ExportToPdf(SfDataGrid sfgrid)
        {
            return base.ExportToPdf(sfgrid);
        }

        public override PdfDocument ExportToPdf(SfDataGrid sfgrid, ICollectionViewAdv view, PdfExportingOptions pdfExportingOptions)
        {
            return base.ExportToPdf(sfgrid, view, pdfExportingOptions);
        }

        public override PdfDocument ExportToPdf(SfDataGrid sfgrid, PdfExportingOptions pdfExportingOptions)
        {
            return base.ExportToPdf(sfgrid, pdfExportingOptions);
        }

        private int startColIndex = 0;

        protected override void SetColumnWidth(SfDataGrid sfgrid, PdfGrid pdfGrid, PdfExportingOptions pdfExportingOptions)
        {
            var gridColumns = pdfExportingOptions.Columns;

            var groupColumnDescriptionsCount = (int)pdfExportingOptions.GetType().GetProperty("GroupColumnDescriptionsCount", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(pdfExportingOptions);

            int columnIndex = groupColumnDescriptionsCount > 0 ? groupColumnDescriptionsCount : startColIndex;
            //After grouping while export to pdf by setting the Export group option as false, need to skip indent column count for setting the columns actual width of PDf grid.
            columnIndex = pdfExportingOptions.ExportGroups ? columnIndex : 0;
            foreach (var column in gridColumns)
            {
                var gridColumn = sfgrid.Columns[column];

                var actualWidth = (float)(gridColumn.ActualWidth / 1.5);

                //set the width for paritucular column while pdf Exporting
                pdfGrid.Columns[columnIndex].Width = 200;
                columnIndex++;
            }
        }
    }
}
         
   

