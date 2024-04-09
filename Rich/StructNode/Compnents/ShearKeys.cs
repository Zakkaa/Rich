using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace StructNode
{
    internal class ShearKeys
    {
        //public SteelPlate oProp;//这里应该是型钢属性
        Part myPart = null;
        public ShearKeys(Part part)
        {
            myPart = part;
        }

        public bool buildShearKey()
        {
            //1、创建腹板方向的四个加劲肋板
            if (myPart == null)
            {
                return false;
            }
            TSG::CoordinateSystem coord = myPart.GetCoordinateSystem();
            TSG.Point point = new TSG.Point(coord.Origin.X, coord.Origin.Y, coord.Origin.Z - 3000);
            Beam beam = new Beam();
            beam.StartPoint = point;
            beam.EndPoint = coord.Origin;
            beam.Profile.ProfileString = "HN400*200*8*13";
            beam.Material.MaterialString = "Q235B";
            beam.Class = "2";
            beam.Position.Rotation = Position.RotationEnum.FRONT;
            beam.Position.Depth = Position.DepthEnum.MIDDLE;
            return beam.Insert();
        }

    }
}
