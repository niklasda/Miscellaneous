// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComInfo.cs" company="Saxo Bank A/S">
//   Info about a COM object
// </copyright>
// <summary>
//   Defines the ComInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ComFinder
{
    /// <summary>
    /// Info about a COM object
    /// </summary>
    public class ComInfo
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public string InprocServer32 { get; set; }

        public string ProgId { get; set; }

        public string ThreadingModel { get; set; }

        public string Version { get; set; }

        public string LocalServer32 { get; set; }

        public string ComponentId { get; set; }

        public string TypeLibraryId { get; set; }

        public string AppID { get; set; }

        public string VersionIndependentProgId { get; set; }
    }
}
