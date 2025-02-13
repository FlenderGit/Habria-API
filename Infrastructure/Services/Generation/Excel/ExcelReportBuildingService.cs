﻿using System.Drawing.Imaging;
using Application.Buildings.Commands.GenerateExcelBuilding;
using Application.Buildings.Queries.GetBuilding;
using Application.Common.Interfaces.Services;
using NPOI.SS.UserModel;
using NPOI.SS.UserModel.Charts;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace Infrastructure.Services.Generation.Excel;
public class ExcelReportBuildingService: IExcelService
{
    public byte[] GenerateExcel(BuildingReportDTO building, IMapService mapService)
    {
        var workbook = new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("jean");

        IRow row_main = sheet.CreateRow(0);
        row_main.CreateCell(0).String(building.Name);
        row_main.CreateCell(1).Numeric(4);
        row_main.CreateCell(3).Numeric(43);

        IDataFormat dataformat = workbook.CreateDataFormat();
        ICell cell = row_main.CreateCell(2);
        cell.Formula("B1/4");
        ICellStyle cellStyle = workbook.CreateCellStyle();
        cellStyle.FillPattern = FillPattern.BigSpots;
        cellStyle.FillForegroundColor = IndexedColors.Blue.Index;
        //cellStyle.DataFormat = dataformat.GetFormat("0.00%");
        cell.CellStyle = cellStyle;

        ICellStyle cellStyleDate = workbook.CreateCellStyle();
        cellStyleDate.DataFormat = dataformat.GetFormat("MM/dd/yyyy HH:mm:ss");

        int i = 2;
        foreach (ObservationViewDTO observation in building.Observations)
        {
            IRow row = sheet.CreateRow(i++);
            row.CreateCell(0).Numeric(observation.Id);
            row.CreateCell(1).Numeric(observation.Id * 2);
            row.CreateCell(2).String(observation.Label);
            ICell dateCell = row.CreateCell(3).Date(observation.Date);
            //cell.CellStyle = cellStyleDate;
        }

        IDrawing drawing = sheet.CreateDrawingPatriarch();
        var anchor = new XSSFClientAnchor
        {
            AnchorType = AnchorType.MoveDontResize,
            Col1 = 10,
            Row1 = 4,
            Col2 = 16,
            Row2 = 17
        };

        // int imageId = LoadPNGImage("wwwroot\\emustream.png", workbook);
        double lat = 49.381075;
        double lng = 3.321258;
        System.Drawing.Image img = mapService.GetImageAtLocation((lat, lng), new System.Drawing.Size(800, 600));

        byte[] mapBytes;
        using (var ms = new MemoryStream())
        {
            img.Save(ms, ImageFormat.Png);
            mapBytes = ms.ToArray();
        }


        int imageId = workbook.AddPicture(mapBytes, PictureType.PNG);
        IPicture pic = drawing.CreatePicture(anchor, imageId);

        IDrawing drawing2 = sheet.CreateDrawingPatriarch();
        var anchor2 = new XSSFClientAnchor()
        {
            AnchorType = AnchorType.MoveDontResize,
            Col1 = 3,
            Row1 = 0,
            Col2 = 8,
            Row2 = 12
        };

        IChart chart = drawing2.CreateChart(anchor2);
        // chart.SetTitle("Jean");

        IChartAxis bottomAxis = chart.ChartAxisFactory.CreateCategoryAxis(AxisPosition.Bottom);
        IValueAxis leftAxis = chart.ChartAxisFactory.CreateValueAxis(AxisPosition.Left);
        leftAxis.Crosses = AxisCrosses.AutoZero;

        IScatterChartData<double, double> data = chart.ChartDataFactory.CreateScatterChartData<double, double>();

        IChartDataSource<double> xs1 = DataSources.FromNumericCellRange(sheet, new CellRangeAddress(2, 5, 0, 0));
        IChartDataSource<double> ys1 = DataSources.FromNumericCellRange(sheet, new CellRangeAddress(2, 5, 1, 1));
        
        IScatterChartSeries<double, double> series1 = data.AddSeries(xs1, ys1);
        series1.SetTitle("V1 Level Fraction");

        chart.Plot(data, bottomAxis, leftAxis);

        using var stream = new MemoryStream();
        workbook.Write(stream);
        return stream.ToArray();
    }

    protected int LoadPNGImage(string path, IWorkbook wb)
    {
        using FileStream file = File.OpenRead(path);
        byte[] buffer = new byte[file.Length];
        file.ReadExactly(buffer, 0, (int)file.Length);
        return wb.AddPicture(buffer, PictureType.PNG);
    }
}
