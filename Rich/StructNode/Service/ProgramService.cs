using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Model;

namespace StructNode.Service
{
    public class ProgramService
    {
        public static Part getPickObjectCoordinate(Model model)
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
    }
}
