using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityApplication.Data;
using UniversityApplication.Data.DTOs;
using UniversityApplication.Data.Models;

namespace UniversityApplication.Service.Service
{
    public class ExamService : IExamService
    {
        private readonly IMapper _mapper;
        private readonly UniversityDataContext _dataContext;

        public ExamService(UniversityDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public bool DeleteExam(int examId)
        {
            var exam = _dataContext.Exams.FirstOrDefault(x => x.Id == examId);

            if (exam == null)
            {
                return false;
            }

            _dataContext.Exams.Remove(exam);
            return _dataContext.SaveChanges() > 0;
        }

        public ExamDTO GetExam(int examId)
        {
            var exam = _dataContext.Exams.FirstOrDefault(x => x.Id == examId);

            return _mapper.Map<ExamDTO>(exam);
        }

        public IEnumerable<ExamDTO> GetExams()
        {
            var exam = _dataContext.Exams.ToList();
            return _mapper.Map<IEnumerable<ExamDTO>>(exam);
        }

        public ExamDTO PutPoints(int id, ExamDTO examObject)
        {
            var exam = _dataContext.Exams.FirstOrDefault(x => x.Id == id);
            if (exam == null)
            {
                throw new Exception("Exam not found");
            }

            examObject.Id = exam.Id;
            exam = _mapper.Map<Exam>(examObject);
            _dataContext.SaveChanges();


            return _mapper.Map<ExamDTO>(exam);
        }

        public ExamDTO SaveExam(ExamDTO exam)
        {
            Exam newExam = _mapper.Map<Exam>(exam);

            _dataContext.Exams.Add(newExam);
            _dataContext.SaveChanges();

            return _mapper.Map<ExamDTO>(newExam);
        }
    }
}
