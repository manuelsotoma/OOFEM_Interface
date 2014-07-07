using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace safeprojectname
{
    public class infoclassname : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "BeamComponent";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("$4561aeb8-65fa-4cc3-b3b0-97974848d19e$");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}