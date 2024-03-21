using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;

namespace CyberSimAware.Models
{
    public class Sim
    {
        // EF will instruct the database to automatically generate this value
        public int SimID { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }  // foreign key property

        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter a sim code.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a sim name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a sim abstract.")]
        public string Abstract { get; set; }

        [Required(ErrorMessage = "Please enter the sims information.")]
        public string Info { get; set; }

        public string Slug {
            get {
                if (Name == null)
                    return "";
                else
                    return Name.Replace(' ', '-');
            }
        }
    }
}