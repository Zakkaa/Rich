using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace StructNode
{
    internal class StiffenerForWeb
    {
        //public SteelPlate oProp;
        Part myPart = null;
        public StiffenerForWeb(Part part)
        {
            myPart = part;
        }

        public bool buildSteelPlates()
        {
            //1、创建腹板方向的四个加劲肋板
            if (myPart == null)
            {
                return false;
            }
            //2、获取主构件截面高度
            ProfileVarsService profileVars = new ProfileVarsService(myPart);
            double dThickness = profileVars.GetProfileWebThickness();
            //3、右上方钢板
            if (!buildSteelPlate(dThickness, true, true))
                return false;
            //4、左上方钢板
            if (!buildSteelPlate(dThickness, true, false))
                return false;
            //5、右下方钢板
            if (!buildSteelPlate(dThickness, false, true))
                return false;
            //6、左下方钢板
            if (!buildSteelPlate(dThickness, false, false))
                return false;
            return true;
        }

        public bool buildSteelPlate(double dThickness, bool bIsUp, bool bIsRight)
        {
            ContourPlate CP = new ContourPlate();
            //1、先获取主构件的坐标位置
            TSG::CoordinateSystem coord = myPart.GetCoordinateSystem();
            //2、计算钢板布置位置的起始点
            TSG::Point p = coord.Origin;
            if (bIsUp)
                p.Y += 100;//TODOI，标注值
            else
                p.Y -= 100;
            if (bIsRight)
                p.X += dThickness / 2.0;
            else
                p.X -= dThickness / 2.0;
            p.Z += 100;//底板的厚度

            //3、绘制截面
            List<ContourPoint> points = buildPoly(p, bIsUp, bIsRight);
            foreach (ContourPoint point in points)
            {
                CP.AddContourPoint(point);
            }
            CP.Position.Depth = Position.DepthEnum.FRONT;
            //4、随便写几个属性
            CP.Finish = "FOO";
            CP.Class = "13";
            CP.Profile.ProfileString = "PL15";
            CP.Material.MaterialString = "Steel_Undefined";
            return CP.Insert(); ;
        }

        public List<ContourPoint> buildPoly(TSG::Point point, bool bIsUp, bool bIsRight)
        {
            int nFlags = bIsRight ? 1 : -1;
            List<ContourPoint> points = new List<ContourPoint>();
            ContourPoint point1 = new ContourPoint(new TSG::Point(point.X, point.Y, point.Z), null);
            ContourPoint point2 = new ContourPoint(new TSG::Point(point.X, point.Y, point.Z + 300), null);
            ContourPoint point3 = new ContourPoint(new TSG::Point(point.X + 250 * nFlags, point.Y, point.Z + 300), null);
            ContourPoint point4 = new ContourPoint(new TSG::Point(point.X + 250 * nFlags, point.Y, point.Z), null);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);

            if ((bIsRight && !bIsUp) || (!bIsRight && bIsUp))
                points.Reverse();
            return points;
        }
    }
}
