# How to set custom column width while exporting to PDF in WPF DataGrid (SfDataGrid)?

## About the sample
This example illustrates how to set custom column width while exporting to PDF in [WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) (SfDataGrid)?

[WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) (SfDataGrid) does not provide the direct support to set custom column width while exporting to PDF. You can set custom column width while exporting to PDF by overriding [SetColumnWidth](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.Converter.SfDataGridToPdfConverter.html#Syncfusion_UI_Xaml_Grid_Converter_SfDataGridToPdfConverter_SetColumnWidth_Syncfusion_UI_Xaml_Grid_SfDataGrid_Syncfusion_Pdf_Grid_PdfGrid_Syncfusion_UI_Xaml_Grid_Converter_PdfExportingOptions_) method in [SfDataGridToPdfConverter](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.Converter.SfDataGridToPdfConverter.html).

```C#

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

```

![Shows the customizing column width while exporting to PDF in SfDataGrid](CustomColumnWidth.gif)

Take a moment to peruse the [WPF DataGrid - Export To PDF](https://help.syncfusion.com/wpf/datagrid/export-to-pdf) documentation, where you can find about export to PDF with code examples.

KB article - [How to set custom column width while exporting to PDF in WPF DataGrid (SfDataGrid)?](https://www.syncfusion.com/kb/12650/how-to-set-custom-column-width-while-exporting-to-pdf-in-wpf-datagrid-sfdatagrid)

## Requirements to run the demo
Visual Studio 2015 and above versions
