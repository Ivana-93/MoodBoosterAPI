using MoodAPI.Bases;
using MoodAPI.Models.Auth;
using MoodAPI.Models;
using MoodAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MoodAPI.Auth;

namespace MoodAPI.Controllers
{
    public class QuestionController : BaseController
    {

        [HttpPost]
        [Route("api/addquestions")]
        public BaseResponse AddQuestion()
        {

            var questions = new Questions

            {
                QuestionList = new List<Question>
                {
                     new Question
                    {   
                        Id = 0,
                        QuestionText = "Are you worried right now? ",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "Only about the end of the world, death, wars…my anxiety is kicking!"
                            },
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "No – everything’s good."
                            },
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "Little, I have stuff I need to do."
                            },

                        }
                    },

                    new Question
                    {
                        Id = 1,
                        QuestionText = "If you could do anything right now, what would you do? ",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "I want to be with my loved ones. "
                            },
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "Sleep."
                            },
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "Watch TV for hours."
                            }
                        }
                    },
                     new Question
                    {
                        Id = 2,
                        QuestionText = "You have a call. You: ",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "Ignore a call."
                            },
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "Answer, why not? "
                            },
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "Answer, just because it polite but I don’t want to talk much"
                            }
                        }
                    },
                      new Question
                    {
                        Id = 3,
                        QuestionText = "The weather is great, and the temperature is just right. What are you going to do today? ",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "Get outside and do something nice! "
                            },
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "Watch TV, play on my phone, nothing too exciting. "
                            },
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "The same thing I do every day. "
                            }
                        }
                    },
                      new Question
                    {
                        Id = 4,
                          QuestionText = "How much time do you spend on the social media?",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "An hour or so. Just to catch up."
                            },
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "Hours and hours."
                            },
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "None or very little."
                            }
                        }
                    },
                      new Question
                    {
                        Id = 5,
                          QuestionText = "What type of food are you currently craving?",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "Anything, something that I can easily make."
                            },
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "I don’t have an appetite right now. "
                            },
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "Maybe something new? Why not? "
                            }
                        }
                    },
                      new Question
                    {
                        Id = 6,
                          QuestionText = "How much energy do you feel?",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "Tons. I could run a marathon. "
                            },
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "I feel sleepy and tired. "
                            },
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "Low, but I will make it till the night."
                            }
                        }
                    },
                      new Question
                    {
                        Id = 7,
                          QuestionText = "How’s your self esteem right now?",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "I know I’m the best!"
                            },
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "It’s fine! "
                            },
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "What self esteem? "
                            }
                        }
                    },
                      new Question
                    {
                        Id = 8,
                          QuestionText = "If you could have any superpower right now what would it be?",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "Invisibility."
                            },
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "Flying."
                            },
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "Fast forward the time."
                            }
                        }
                    },
                      new Question
                    {
                        Id = 9,
                          QuestionText = "What kind of music are you listening at the moment?",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Point = 2,
                                AnswerText = "Pop/dance/rock/metal – I shuffle."
                            },
                            new Answer
                            {
                                Point = 1,
                                AnswerText = "Acoustic songs."
                            },
                            new Answer
                            {
                                Point = 3,
                                AnswerText = "My favorite playlist."
                            }
                        }
                    },

                }
            };

            try
            {
                FirebaseService.Instance.AddQuestions(questions);
                return CreateOkResponse();
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e.Message);
            }

        }


        [HttpGet]
        [Route("api/questions")]

        public BaseResponse GetQuestions()
        {
            try
            {
                var questions = FirebaseService.Instance.GetQuestions();
                return CreateOkResponse(questions);     
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e);
            }
        }


        [HttpGet]
        [Route("api/question/{id}")]

        public BaseResponse GetQuestion(int id)
        {
            try
            {
                var questions = FirebaseService.Instance.GetQuestions();
                return CreateOkResponse(
                    questions.QuestionList.First(question => question.Id == id));

                /*foreach (var question in questions.QuestionList) 
                {
                    if (question.Id == id)
                    {
                        return CreateOkResponse(question);
                    }

                }*/
                //throw new Exception("Invalid id");
                
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e);
            }
        }

    }
}



