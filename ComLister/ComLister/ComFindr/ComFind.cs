// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComFind.cs" company="Saxo Bank A/S">
//   Find Coms
// </copyright>
// <summary>
//   Defines the ComFind type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using COMAdmin;

namespace ComFinder
{
    /// <summary>
    /// Com object finder
    /// </summary>
    public class ComFind
    {
        /// <summary>
        /// Get COM+ Applications
        /// </summary>
        /// <returns>
        /// COM+ applications
        /// </returns>
        public IList<ComInfo> GetComPlus()
        {
            IList<ComInfo> comPlusList = new List<ComInfo>();

            try
            {
                COMAdminCatalog objAdmin = new COMAdminCatalog();
                object objRoot = objAdmin.Connect("127.0.0.1");

                var objCollection = (COMAdminCatalogCollection)objAdmin.GetCollection("Applications");
                objCollection.Populate();

                foreach (COMAdminCatalogObject obj in objCollection)
                {
                    ComInfo info = new ComInfo();
                    info.Caption = obj.get_Value("Name") as string; // =obj.Name
                    info.Description = obj.get_Value("Description") as string;
                    info.AppID = obj.get_Value("ID") as string; // = obj.Key
                    info.InprocServer32 = obj.get_Value("Identity") as string;
                    info.LocalServer32 = obj.get_Value("Activation") as string;
                    
                    comPlusList.Add(info);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ComInfo info = new ComInfo();
                info.Description = ex.Message;
                comPlusList.Add(info);
            }

            return comPlusList;
        }

        /// <summary>
        /// use WMI to find COM objects
        /// </summary>
        /// <returns>
        /// The COM objects.
        /// </returns>
        public IList<ComInfo> GetCom()
        {
            IList<ComInfo> comObjectList = new List<ComInfo>();

            ConnectionOptions options = new ConnectionOptions();
            ManagementPath path = new ManagementPath(string.Format("\\\\{0}\\root\\cimv2", "127.0.0.1"));

            try
            {
                ManagementScope scope = new ManagementScope(path, options);
                scope.Connect();

                ObjectQuery query = new ObjectQuery("Select * from Win32_ClassicCOMClassSetting");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection manObjs = searcher.Get();
                foreach (ManagementObject manObj in manObjs)
                {
                    ComInfo info = new ComInfo();

                    info.Caption = manObj["Caption"] as string;
                    info.Description = manObj["Description"] as string;
                    info.InprocServer32 = manObj["InprocServer32"] as string;
                    info.ProgId = manObj["ProgId"] as string;
                    info.ThreadingModel = manObj["ThreadingModel"] as string;
                    info.Version = manObj["Version"] as string;
                    info.LocalServer32 = manObj["LocalServer32"] as string;
                    info.ComponentId = manObj["ComponentId"] as string;
                    info.TypeLibraryId = manObj["TypeLibraryId"] as string;
                    info.AppID = manObj["AppID"] as string;
                    info.VersionIndependentProgId = manObj["VersionIndependentProgId"] as string;

                    if (info.Caption == null)
                    {
                        info.Caption = string.Empty;
                    }

                    comObjectList.Add(info);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ComInfo info = new ComInfo();
                info.Description = ex.Message;
                comObjectList.Add(info);
            }

            return comObjectList;
        }
    }
}
