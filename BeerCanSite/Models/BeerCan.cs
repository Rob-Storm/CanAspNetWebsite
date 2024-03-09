using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BeerCanSite.Models
{
    public class BeerCan
    {
        #region Fields
        public int Id { get; set; }
        [Display(Name ="Name")]
        public string BeerCanName { get; set; }

        [Display(Name = "Brand")]
        public string BeerBrand { get; set; }

        [Display(Name = "Description")]
        public string? BeerCanDescription { get; set; }

        //accept values no lower than 1935
        [Display(Name = "Manufacture Date")]
        public int ManufactureDate { get; set; }

        [Display(Name = "Top Type")]
        public TopType TopType { get; set; }

        [Display(Name = "Opened Status")]
        public OpenedStatus OpenedStatus { get; set; }


        //No larger than 640
        [Display(Name = "Container Size (fl oz)")]
        public int ContainerSize { get; set; }

        public int Grade { get; set; }

        public bool Circulated { get; set; }
        public bool Instructional { get; set; }
        public byte[]? Images { get; set; }

        #endregion
        public BeerCan()
        {

        }
    }
    public enum TopType
        {
            [Display(Name = "Cone Top")]
            ConeTop,

            [Display(Name = "Flat Top")]
            FlatTop,

            [Display(Name = "Seventies Tab")]
            SeventiesTab,

            [Display(Name = "Never Topped")]
            NeverTopped,

            [Display(Name = "Removed Top")]
            RemovedTop,

            [Display(Name = "Button Top")]
            ButtonTop,

            [Display(Name = "Modern Top")]
            ModernTop
        };

        public enum OpenedStatus
        {
            [Display(Name = "Top Openeed")]
            TopOpened,

            [Display(Name = "Bottom Opened")]
            BottomOpened,

            [Display(Name = "Never Opened")]
            NeverOpened
        };
}