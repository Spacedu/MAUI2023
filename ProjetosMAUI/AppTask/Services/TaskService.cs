﻿using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Services
{
    public class TaskService : ITaskService
    {
        private HttpClient _http;

        public TaskService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<TaskModel>> GetAll(Guid userId)
        {
            return await _http.GetFromJsonAsync<List<TaskModel>>($"tasks?userId={userId}");
        }

        public async Task Add(TaskModel task)
        {
            await _http.PostAsJsonAsync<TaskModel>("tasks", task);
        }

        public async Task Update(TaskModel task)
        {
            await _http.PutAsJsonAsync<TaskModel>("tasks", task);
        }
        public async Task Delete(Guid id)
        {
            await _http.DeleteAsync($"tasks/{id}");
        }

        public async Task<List<TaskModel>> BatchPush(Guid userId, List<TaskModel> tasks)
        {
            var httpMsg = await _http.PostAsJsonAsync($"tasks/batchpush/{userId}", tasks);

            if(httpMsg.IsSuccessStatusCode)
            {
                return await httpMsg.Content.ReadFromJsonAsync<List<TaskModel>>();
            }
            
            throw new HttpRequestException(
                $"Erro ao consumir o BatchPush: {await httpMsg.Content.ReadAsStringAsync()}",
                null,
                httpMsg.StatusCode);
        }
    }
}
