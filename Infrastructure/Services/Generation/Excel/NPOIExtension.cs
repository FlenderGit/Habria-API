using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;

namespace Infrastructure.Services.Generation.Excel;
public static class ExcelServiceB
{
    public static ICell String(this ICell cell, string value)
    {
        cell.SetCellValue(value);
        return cell;
    }

    public static ICell Numeric(this ICell cell, double value)
    {
        // cell.SetCellType(CellType.Numeric);
        cell.SetCellValue(value);
        return cell;
    }

    public static ICell Numeric(this ICell cell, string value)
    {
        double numerizedValue = Convert.ToDouble(value);
        cell.Numeric(numerizedValue);
        return cell;
    }

    public static ICell Formula(this ICell cell, string value)
    {
        cell.SetCellFormula(value);
        return cell;
    }

    public static ICell Date(this ICell cell, DateTime date)
    {
        cell.SetCellValue(date.ToString("yyyy-MM-dd"));
        return cell;
    }
}
