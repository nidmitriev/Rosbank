using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RosbankHelpCenter.API.Data;
using RosbankHelpCenter.API.Dtos;
using AutoMapper;
using System.Linq;

namespace RosbankHelpCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDatingRepository _repo;

        public QuestionsController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
           
            var questions = (await _repo.GetQuestions());

            var questionsToReturn = _mapper.Map<IEnumerable<QuestionForListDto>>(questions);

            return Ok(questionsToReturn);
        }

        [HttpGet("q_v{vip}_ty{type}")]
        public async Task<IActionResult> GetQuestion(bool vip, bool type)
        {
            var question = await _repo.GetQuestion(type);

            var questionToReturn = _mapper.Map<IEnumerable<QuestionForFirstCall>>(question);

            return Ok(questionToReturn);
        }

        [HttpGet("q_q{user_question}")]
        public async Task<IActionResult> GetQuestion(string user_question)
        {
            var question = await _repo.GetQuestion(user_question);

            //  нужно поставить ограничение на 5 лучших (??)

            var questionToReturn = _mapper.Map<IEnumerable<QuestionForSecondCall>>(question);

            return Ok(questionToReturn);
        }
    }

}