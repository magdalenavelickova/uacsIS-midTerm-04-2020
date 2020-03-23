using System;
using System.Collections.Generic;
using System.Text;
using UniversityApplication.Data.DTOs;

namespace UniversityApplication.Service.Service
{
    public interface IExamService
    {
        IEnumerable<ExamDTO> GetExams();

        ExamDTO GetExam(int examId);

        ExamDTO SaveExam(ExamDTO exam);

        bool DeleteExam(int examId);

        ExamDTO PutPoints(int id, ExamDTO examObject);
    }
}
