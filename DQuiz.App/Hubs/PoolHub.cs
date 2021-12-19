using System;
using System.Threading.Tasks;
using DQuiz.Data.App.Quiz;
using Microsoft.AspNetCore.SignalR;

namespace DQuiz.MVC.Hubs
{
    public class PoolHub : Hub
    {
        public Task Broadcast(TrueFalseCount information)
        {
            return Clients.All
                .SendAsync("Broadcast", information);
        }

        public Task BroadcastByQuestion(QuestionBasedTrueFalseObject information)
        {
            return Clients.All.SendAsync("BroadcastByQuestion",information);
        }

        public Task ResetSingleBarChart()
        {
            return Clients.All.SendAsync("ResetSingleBarChart");
        }

        public Task NextQuestion()
        {
            return Clients.All.SendAsync("NextQuestion");
        }

        public Task StartContest()
        {
            return Clients.All.SendAsync("StartContest");
        }

        public Task EndCountdown()
        {
            return Clients.All.SendAsync("EndCountdown");
        }

        public Task UpdateCounter(int seconds)
        {
            return Clients.All.SendAsync("UpdateCounter", seconds);
        }
    }
}
