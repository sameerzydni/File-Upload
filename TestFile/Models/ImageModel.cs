using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestFile.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string FirstName { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string LastName { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string Email { get; set; }

        //public DateTime? Dates { get; set; }

        //public int ContactNo { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string Qualification { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string SkillSet { get; set; }

        //[Column(TypeName = "nvarchar(5)")]
        //public string Experience { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string? Reference { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string? Status { get; set; }

        //[Column(TypeName = "nvarchar(MAX)")]
        //public string? Comments { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
    }
}
