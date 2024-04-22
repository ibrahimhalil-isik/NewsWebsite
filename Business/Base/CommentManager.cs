﻿using Business.Abstract;
using DataAccess.Abstract.Repository;
using Shared.Dtos;
using Shared.Entities;

namespace Business.Base
{
    public class CommentManager : ICommentService
    {
        private readonly IRepository<Comment> _repository;
        public CommentManager(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public CommentDto Add(CommentDto model)
        {
            var response = _repository.Add(CommentItem(model));
            return CommentItem(response);
        }

        public CommentDto Update(CommentDto model)
        {
            var comment = _repository.GetById(model.CommentId);
            Comment response  = _repository.Update(comment);
            return CommentItem(response);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(new Comment { CommentId = id});
        }        

        public List<CommentDto> GetAll()
        {
            var response = _repository.GetAll().ToList();
            List<CommentDto> result = new List<CommentDto>();

            foreach (var item in response)
            {
                result.Add(CommentItem(item));
            }
            return result;
        }

        public CommentDto GetById(int id)
        {
            var response = _repository.GetById(id);
            return CommentItem(response);
        }

        private CommentDto CommentItem (Comment model)
        {
            CommentDto result = new CommentDto();
            result.CommentId = model.CommentId;
            result.CommentText = model.CommentText;
            result.CommentTitle = model.CommentTitle;
            result.CommentDate = model.CommentDate;
            result.Name = model.Name;
            result.Surname = model.Surname;
            result.Email = model.Email;
            result.NewsId = model.NewsId;
            result.CommentStatus = model.CommentStatus;

            return result;
        }
        private Comment CommentItem(CommentDto model)
        {
            Comment result = new Comment();
            result.CommentId = model.CommentId;
            result.CommentText = model.CommentText;
            result.CommentTitle = model.CommentTitle;
            result.CommentDate = model.CommentDate;
            result.Name = model.Name;
            result.Surname = model.Surname;
            result.Email = model.Email;
            result.NewsId = model.NewsId;
            result.CommentStatus = model.CommentStatus;

            return result;
        }
    }
}
