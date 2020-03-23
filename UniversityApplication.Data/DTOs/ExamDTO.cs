using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UniversityApplication.Data.Validators;

namespace UniversityApplication.Data.DTOs
{
    public class ExamDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of an Exam")]
        public int Id { get; set; }

        [StringLength(400, ErrorMessage = "The Name value cannot exceed 400 characters. ")]
        public string Name { get; set; }

        [StringLength(400, ErrorMessage = "The ProfessorName value cannot exceed 400 characters. ")]
        public string ProfessorName { get; set; }

        [Required(ErrorMessage = "You have to add Credits")]
        [Range(5, int.MaxValue, ErrorMessage = "Credits needs to be greater than 5")]
        public decimal Credits { get; set; }
    }
}
