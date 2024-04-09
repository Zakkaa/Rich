using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Model;

namespace StructNode
{
    internal class CreateStructService
    {
        public Part getPickObjectCoordinate(Model model)
        {
            Picker picker = new Picker();
            try
            {
                Part part = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Please Select Part") as Part;
                return part;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public void Create()
        {
            Model model = new Model();
            if (!model.GetConnectionStatus())
            {
                return;
            }
            Part part = getPickObjectCoordinate(model);
            ColumnSoleplate columnSoleplate = new ColumnSoleplate(part);
            columnSoleplate.buildSteelPlate();
            StiffenersForFlange stiffeners = new StiffenersForFlange(part);
            stiffeners.buildSteelPlates();
            StiffenerExtensionFlange stiffenerExtensionFlange = new StiffenerExtensionFlange(part);
            stiffenerExtensionFlange.buildSteelPlates();
            StiffenerForWeb stiffenerForWeb = new StiffenerForWeb(part);
            stiffenerForWeb.buildSteelPlates();
            ShearKeys shearKey = new ShearKeys(part);
            shearKey.buildShearKey();
            model.CommitChanges();
        }

    }
}
