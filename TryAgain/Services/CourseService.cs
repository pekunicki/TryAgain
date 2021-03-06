﻿using System.Collections.Generic;
using AutoMapper;
using TryAgain.Models;
using TryAgain.Persistance.Entity;
using TryAgain.Persistance.Repository;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<CourseModel> GetAllCourses()
        {
            var courses = _courseRepository.GetAllCourses();
            return Mapper.Map<List<CourseModel>>(courses);
        }

        public List<CourseModel> GetAllMatchedCourses(string term, int numberResults)
        {
            var courses = _courseRepository.GetAllMatchedCourses(term, numberResults);
            return Mapper.Map<List<CourseModel>>(courses);
        }

        public bool CheckIfCourseExists(string courseName)
        {
            var course = _courseRepository.GetCourseByName(courseName);
            return course != null;
        }

        public CourseModel GetCourseByCourseName(string coursename)
        {
            var course = _courseRepository.GetCourseByName(coursename);
            var courseModel = MapToCourseModel(course);
            return courseModel;
        }

        public CourseModel GetCourseById(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            var courseModel = MapToCourseModel(course);
            return courseModel;
        }

        private static CourseModel MapToCourseModel(Course course)
        {
            var courseModel = Mapper.Map<CourseModel>(course);
            return courseModel;
        }
    }
}