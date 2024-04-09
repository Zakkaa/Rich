using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using TSG = Tekla.Structures.Geometry3d;

namespace StructNode
{
    internal class ColumnSoleplate
    {
        //public SteelPlate oProp;
        Part myPart = null;
        public ColumnSoleplate(Part part) 
        { 
            myPart = part;
        }

        public List<ContourPoint> buildPoly()
        {
            List<ContourPoint> points = new List<ContourPoint>();
            if (myPart == null)
                return points;
            TSG::CoordinateSystem coord = myPart.GetCoordinateSystem();
            ContourPoint point1 = new ContourPoint(new TSG::Point(coord.Origin.X - 500, coord.Origin.Y - 500, 0), null);
            ContourPoint point2 = new ContourPoint(new TSG::Point(coord.Origin.X + 500, coord.Origin.Y - 500, 0), null);
            ContourPoint point3 = new ContourPoint(new TSG::Point(coord.Origin.X + 500, coord.Origin.Y + 500, 0), null);
            ContourPoint point4 = new ContourPoint(new TSG::Point(coord.Origin.X - 500, coord.Origin.Y + 500, 0), null);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            return points;
        }

        public bool buildSteelPlate()
        {
            ContourPlate CP = new ContourPlate();
            List<ContourPoint> points = buildPoly();
            foreach (ContourPoint point in points)
            {
                CP.AddContourPoint(point);
            }
            CP.Position.Depth = Position.DepthEnum.FRONT;
            //随便写几个属性
            CP.Finish = "FOO";
            CP.Class = "13";
            CP.Profile.ProfileString = "PL100";
            CP.Material.MaterialString = "Steel_Undefined";
            return CP.Insert();
        }
    }
}
