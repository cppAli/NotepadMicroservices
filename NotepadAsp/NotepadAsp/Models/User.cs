using NotepadAsp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApp.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
