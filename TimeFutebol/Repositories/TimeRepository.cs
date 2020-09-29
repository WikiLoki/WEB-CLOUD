﻿using TimeFutebol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TimeFutebol.Validators;
using System.Runtime.InteropServices;

namespace TimeFutebol.Repositories
{
    public class TimeRepository : ITimeRepository
    {
        private IList<Time> listaTimes = new List<Time>();
        public TimeRepository() {
            listaTimes.Add(new Time() { id = 1, nome = "São Paulo" });
            listaTimes.Add(new Time() { id = 2, nome = "Santos" });
        }
        public Time BuscarTimePorId(int id)
        {

            return listaTimes.Where(x => x.id == id).FirstOrDefault();
        }

        public void InserirTime(Time timao)
        {
            var validator = new TimeValidator();
            var validRes = validator.Validate(timao);
            if (validRes.IsValid)
                listaTimes.Add(timao);
            else
                throw new Exception(validRes.Errors.FirstOrDefault().ToString());
        }

        public IList<Time> ListarTodosTimes()
        {
            return listaTimes;
        }
    }
}
