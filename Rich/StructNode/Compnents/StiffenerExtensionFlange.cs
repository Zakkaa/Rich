using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace StructNode
{
    internal class StiffenerExtensionFlange
    {
        //public SteelPlate oProp;
        Part myPart = null;
        public StiffenerExtensionFlange(Part part)
        {
            myPart = part;
        }

        public bool buildSteelPlates()
        {
            //1、创建翼缘延伸的四个加劲肋板
            if (myPart == null)
            {
                return false;
            }
            //2、获取主构件截面高度
            ProfileVarsService profileVars = new ProfileVarsService(myPart);
            double dHeight = profileVars.GetProfileHeight();
            double dWidth = profileVars.GetProfileWidth();
            //3、右上方钢板
            if (!buildSteelPlate(dHeight, dWidth, true, true))
                return false;
            //4、左上方钢板
            if (!buildSteelPlate(dHeight, dWidth, true, false))
                return false;
            //5、右下方钢板
            if (!buildSteelPlate(dHeight, dWidth, false, true))
                return false;
            //6、左下方钢板
            if (!buildSteelPlate(dHeight, dWidth, false, false))
                return false;
            return true;
        }

        public bool buildSteelPlate(double dHeight, double dWidth, bool bIsUp, bool bIsRight)
        {
            ContourPlate CP = new ContourPlate();
            //1、先获取主构件的坐标位置
            TSG::CoordinateSystem coord = myPart.GetCoordinateSystem();
            //2、计算钢板布置位置的起始点
            TSG::Point p = coord.Origin;
            if (bIsUp)//是否为上翼缘？判断Y方向偏移
                p.Y += dHeight / 2.0;
            else
                p.Y -= dHeight / 2.0;
            if (bIsRight)
                p.X += dWidth / 2.0;
            else
                p.X -= dWidth / 2.0;
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
            ContourPoint point3 = new ContourPoint(new TSG::Point(point.X + 150 * nFlags, point.Y, point.Z + 300), null);
            ContourPoint point4 = new ContourPoint(new TSG::Point(point.X + 150 * nFlags, point.Y, point.Z), null);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);

            if ((bIsRight && bIsUp) || (!bIsRight && !bIsUp))
                points.Reverse();
            return points;
        }
    }
}
