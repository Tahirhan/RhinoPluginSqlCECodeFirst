using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace RhinoPluginSqlCECodeFirst
{
    public class RhinoPluginSqlCECodeFirstCommand : Command
    {
        public RhinoPluginSqlCECodeFirstCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static RhinoPluginSqlCECodeFirstCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "TestInsertDataToECDatabase"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            using(ModelSqlCECodeFirst db = new ModelSqlCECodeFirst())
            {
                try
                {
                    db.MyEntities.Add(new MyEntity()
                    {
                        Name = "TestName"
                    });
                    db.SaveChanges();
                } catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            }

            return Result.Success;
        }
    }
}
