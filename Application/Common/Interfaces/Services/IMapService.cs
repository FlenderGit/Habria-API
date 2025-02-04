using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;
public interface IMapService
{
    Image GetImageAtLocation((double latitude, double longitude) coordinates, Size size, int zoom = 2000, string urlFormatter = null);
}
