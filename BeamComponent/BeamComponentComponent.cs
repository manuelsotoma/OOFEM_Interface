using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using GH_OOFEM;

namespace BeamComponent
{
    public class BeamComponentComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public BeamComponentComponent()
            : base("BeamComponent", "Beam",
                "Description",
                "OOFEM", "Elements")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddLineParameter("Line", "Line", "", GH_ParamAccess.list);
            pManager.AddPlaneParameter("LocalCoordinateSystem", "LCS", "", GH_ParamAccess.list);
            pManager[1].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Beam", "B", "", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Line>          axisList = new List<Line>();
            List<ElementBeam>   beamList = new List<ElementBeam>();

            DA.GetDataList(0, axisList);
                
            foreach (Line mainAxis in axisList)
            {
                GH_OOFEM.ElementBeam beam;
                if (mainAxis.Length == 0)
                {
                    beam = new ElementBeam();
                }
                else
                {
                    beam = new ElementBeam(mainAxis);
                }
                beamList.Add(beam);
            }
            DA.SetDataList(0, beamList);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{9fd9f3aa-fa2d-41c7-b305-4a5a05baadff}"); }
        }
    }
}
